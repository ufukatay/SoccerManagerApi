using Bogus;
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
        private readonly Randomizer _randomizer;
        public TeamRepository(ApplicationDbContext context) 
        {
            _context = context;
            _randomizer = new Randomizer();
        }
        public async Task<List<Team>> GetAllTeams()
        {
            return await _context.Teams.Include(p => p.Players).ToListAsync();
        }

        public async Task<Team> CreateNewTeam(Team team)
        {
            var playerFaker = new Faker<Player>()
                .RuleFor(p => p.firstName, f => f.Person.FirstName)
                .RuleFor(p => p.lastName, f => f.Person.LastName)
                .RuleFor(p => p.country, f => f.Address.Country())
                .RuleFor(p => p.age, f => f.Random.Number(18, 40))
                .RuleFor(p => p.marketValue, f => 1000000)
                .RuleFor(p => p.position, f => f.PickRandom("gk", "dm", "rb", "lb", "cdm", "cm", "rm", "lm", "lw", "rw", "cam", "cf", "st"));

            for (int i = 0; i < 20; i++)
            {
                var randomPlayer = playerFaker.Generate();
                team.Players.Add(randomPlayer);
            }

            team.teamValue = team.Players.Sum(player => (int)player.marketValue);
            team.teamValue += 5000000; 

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
