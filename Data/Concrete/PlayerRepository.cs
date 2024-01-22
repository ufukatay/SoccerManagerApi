using Bogus;
using Data.Abstract;
using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public async Task<Player> BuyPlayer(int id, Player player)
        {
            var existPlayer = await _context.Players.FindAsync(id);

            int formerTeamId = existPlayer.TeamId;
            int newTeamId = player.TeamId;

            if (existPlayer == null || existPlayer.isInTranferList == false || formerTeamId == newTeamId)
            {
                return null;
            }

            

            double val = existPlayer.askedPrice;

            var playerFaker = new Faker<Player>()
                .RuleFor(p => p.marketValue, f => f.Random.Double(val * 1.1, val * 2));


            existPlayer.askedPrice = 0;
            existPlayer.isInTranferList = false;
            existPlayer.TeamId = player.TeamId;
            existPlayer.marketValue = playerFaker.Generate().marketValue;

            await _context.SaveChangesAsync();

            return existPlayer;
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

        public async Task<List<Player>> GetTransferList()
        {
            return await _context.Players
                .Where(p => p.isInTranferList)
                .ToListAsync();
        }


        public async Task<Player?> TransferListPlayer(int id, Player player)
        {
            var existPlayer = await _context.Players.FindAsync(id);

            if (existPlayer == null)
            {
                return null;
            }

            existPlayer.askedPrice = player.askedPrice;
            existPlayer.isInTranferList = true;

            await _context.SaveChangesAsync();

            return existPlayer;
        }

        public async Task<Player?> UpdatePlayerData(int id, Player player)
        {
            var existPlayer = await _context.Players.FindAsync(id);

            if (existPlayer == null)
            {
                return null;
            }

            existPlayer.firstName = player.firstName;
            existPlayer.lastName = player.lastName;
            existPlayer.country = player.country;

            await _context.SaveChangesAsync();

            return existPlayer;
        }
    }
}
