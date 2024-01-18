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
        Task<Player> UpdatePlayerData(int id, Player player);
        Task DeletePlayer(int id);
        Task<Player> TransferListPlayer(int id, Player player);
        Task<List<Player>> GetTransferList();
    }
}
