using Entitites.Dtos.Team;
using Entitites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Mappers
{
    public static class TeamMappers
    {
        public static TeamDto ToTeamDto(this Team team)
        {
            return new TeamDto
            {
                Id = team.Id,
                teamName = team.teamName,
                teamValue = team.teamValue,
                teamCountry = team.teamCountry,
            };
        }

        public static Team ToTeamFromCreateDto(this CreateTeamDto team)
        {
            return new Team
            {
                teamCountry = team.teamCountry,
                teamName = team.teamName,
            };
        }

    }
}
