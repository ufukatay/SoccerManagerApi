﻿using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllTeams();
        Task UpdateTeamValue(int id);
        Task<Team> GetTeamById(int id);
        Task<Team> CreateNewTeam(Team team);
        Task<Team> UpdateTeamData(int id, Team team);
        Task DeleteTeam(int id);
    }
}

