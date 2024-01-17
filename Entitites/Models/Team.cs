using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Entitites.Models
{
    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string teamName { get; set; }
        [Required]
        [StringLength(50)]
        public string teamCountry { get; set; }

        private int _teamValue;
        public int? teamValue
        {
            get { return _teamValue; }
            set { _teamValue = value ?? 0; }
        }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
