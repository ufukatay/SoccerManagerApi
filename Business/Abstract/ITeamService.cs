using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamService
    {
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeamById(int id);
        Task<Team> CreateNewTeam(Team team);
        Task<Team> UpdateTeam(Team team);
        Task DeleteTeam(int id);
    }
}
