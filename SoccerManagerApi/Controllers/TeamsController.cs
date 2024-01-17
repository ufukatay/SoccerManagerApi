using Business.Abstract;
using Entitites.Dtos.Team;
using Entitites.Mappers;
using Entitites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoccerManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeams();
            var teamDtos = teams.Select(t => t.ToTeamDto()).ToList();
            return Ok(teams); //200
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound(); //404
            }
            return Ok(team.ToTeamDto());
        }
        [HttpPost]
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
        [Route("{id}")]
        public async Task<IActionResult> UpdateTeam([FromBody] Team team)
        {
            if (await _teamService.GetTeamById(team.Id) != null)
            {
                await _teamService.UpdateTeam(team);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTeamById(int id)
        {
            if (await _teamService.GetTeamById(id) != null)
            {
                await _teamService.DeleteTeam(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
