using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<Player> CreateNewPlayer(Player player);
        Task<Player> UpdatePlayer(Player player);
        Task DeletePlayer(int id);
    }
}
