using Business.Abstract;
using Data.Abstract;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Task<Player> CreateNewPlayer(Player player)
        {
            return _playerRepository.CreateNewPlayer(player);
        }

        public Task DeletePlayer(int id)
        {
            return _playerRepository.DeletePlayer(id);
        }

        public Task<List<Player>> GetAllPlayers()
        {
            return _playerRepository.GetAllPlayers();
        }

        public Task<Player> GetPlayerById(int id)
        {
            return _playerRepository.GetPlayerById(id);
        }

        public Task<Player> UpdatePlayer(Player player)
        {
            return _playerRepository.UpdatePlayer(player);
        }
    }
}
