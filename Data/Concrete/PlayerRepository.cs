using Data.Abstract;
using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;
        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> CreateNewPlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayer(int id)
        {
            var deletedPlayer = await GetPlayerById(id);
            if (deletedPlayer != null)
            {
                _context.Players.Remove(deletedPlayer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
