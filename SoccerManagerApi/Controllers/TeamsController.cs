using Business.Abstract;
using Business.Concrete;
using Entitites.Dtos.Player;
using Entitites.Dtos.Team;
using Entitites.Mappers;
using Entitites.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoccerManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeams();
            var teamDtos = teams.Select(t => t.ToTeamDto()).ToList();
            return Ok(teamDtos); //200
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound(); //404
            }
            return Ok(team);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNewTeam([FromBody] CreateTeamDto team)
        {
            var teamModel = team.ToTeamFromCreateDto();
            if (await _teamService.GetTeamById(teamModel.Id) == null)
            {
                return Ok(await _teamService.CreateNewTeam(teamModel));
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> UpdateTeamData([FromRoute] int id, [FromBody] UpdateTeamDto updateTeamDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var team = await _teamService.UpdateTeamData(id, updateTeamDto.ToTeamFromUpdate());
            if (team == null)
            {
                return NotFound("Team not found.");
            }

            return Ok(team.ToTeamDto());
        }
    }
}
