using Data.Abstract;
using Entitites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<List<Team>> GetAllTeams()
        {
            return await _context.Teams.Include(p => p.Players).ToListAsync();
        }

        public async Task<Team> CreateNewTeam(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _context.Teams.Include(p => p.Players).FirstOrDefaultAsync(i => i.Id == id); 
        }

        public async Task<Team> UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task DeleteTeam(int id)
        {
            var deletedTeam = await GetTeamById(id);
            if(deletedTeam != null)
            {
                _context.Teams.Remove(deletedTeam);
                await _context.SaveChangesAsync();
            }
        }
    }
}
