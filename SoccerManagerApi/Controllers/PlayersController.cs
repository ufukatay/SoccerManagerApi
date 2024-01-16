using Business.Abstract;
using Entitites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SoccerManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayers();
            return Ok(players); //200
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerService.GetPlayerById(id);
            if(player == null)
            {
                return NotFound(); //404
            }
            return Ok(player);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewPlayer([FromBody] Player player)
        {
            if(await _playerService.GetPlayerById(player.Id) == null)
            {
                return Ok(await _playerService.CreateNewPlayer(player));
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePlayer([FromBody] Player player)
        {
            if(await _playerService.GetPlayerById(player.Id) != null)
            {
                await _playerService.UpdatePlayer(player);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePlayerById(int id)
        {
            if(await _playerService.GetPlayerById(id) != null)
            {
                await _playerService.DeletePlayer(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
