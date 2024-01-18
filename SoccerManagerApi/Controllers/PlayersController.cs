using Business.Abstract;
using Entitites.Dtos.Player;
using Entitites.Mappers;
using Entitites.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
            var playerDtos = players.Select(p => p.ToPlayerDto()).ToList();
            return Ok(players); //200
        }

        [HttpGet]
        [Route("transferList")]
        public async Task<IActionResult> GetTransferList()
        {
            var players = await _playerService.GetTransferList();
            var playerDtos = players.Select(p => p.ToPlayerDto()).ToList();
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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePlayerData([FromRoute] int id, [FromBody] UpdatePlayerDto updatePlayerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = await _playerService.UpdatePlayerData(id, updatePlayerDto.ToPlayerFromUpdate());
            if(player == null)
            {
                return NotFound("Player not found.");
            }
            
            return Ok(player.ToPlayerDto());
        }


        [HttpPut]
        [Route("transferList/{id}")]
        public async Task<IActionResult> TransferListPlayer([FromRoute] int id, [FromBody] TransferListPlayerDto transferListPlayerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = await _playerService.TransferListPlayer(id, transferListPlayerDto.ToPlayerFromUpdateTransferList());
            if (player == null)
            {
                return NotFound("Player not found.");
            }

            return Ok(player.ToPlayerDto());
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
