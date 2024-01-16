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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Task<Team> CreateNewTeam(Team team)
        {
            return _teamRepository.CreateNewTeam(team);
        }

        public Task DeleteTeam(int id)
        {
            return _teamRepository.DeleteTeam(id);
        }

        public Task<List<Team>> GetAllTeams()
        {
            return _teamRepository.GetAllTeams();
        }

        public Task<Team> GetTeamById(int id)
        {
            return _teamRepository.GetTeamById(id);
        }

        public Task<Team> UpdateTeam(Team team)
        {
            return _teamRepository.UpdateTeam(team);
        }
    }
}
