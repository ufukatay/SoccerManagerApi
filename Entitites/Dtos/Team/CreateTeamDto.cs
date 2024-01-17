using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dtos.Team
{
    public class CreateTeamDto
    {
        public int Id { get; set; }
        public string teamName { get; set; }
        public string teamCountry { get; set; }
    }
}
