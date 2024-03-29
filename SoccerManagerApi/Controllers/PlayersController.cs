﻿using Business.Abstract;
using Entitites.Dtos.Player;
using Entitites.Mappers;
using Entitites.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace SoccerManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        public PlayersController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerService.GetAllPlayers();
            var playerDtos = players.Select(p => p.ToPlayerDto()).ToList();
            return Ok(players); //200
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetTransferList()
        {
            var players = await _playerService.GetTransferList();
            var playerDtos = players.Select(p => p.ToPlayerDto()).ToList();
            return Ok(players); //200
        }

        [HttpGet]
        [Route("[action]/{id}")]
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
        [Route("[action]/{id}")]
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
        [Route("[action]/{id}")]
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

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<IActionResult> BuyPlayer([FromRoute] int id, [FromBody] BuyPlayerDto buyplayerdto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var player = await _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound("Player not found.");
            }
            var formerTeamId = player.TeamId;
            var newPlayer = await _playerService.BuyPlayer(id, buyplayerdto.ToPlayerFromBuyPlayer());

            await _teamService.UpdateTeamValue(buyplayerdto.TeamId);
            await _teamService.UpdateTeamValue(formerTeamId);

            return Ok(newPlayer.ToPlayerDto());
        }
    }
}
