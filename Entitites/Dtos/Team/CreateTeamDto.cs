﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Dtos.Team
{
    public class CreateTeamDto
    {
        public string teamName { get; set; }
        public string teamCountry { get; set; }
    }
}
