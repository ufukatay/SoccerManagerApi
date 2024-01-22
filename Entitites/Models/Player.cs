using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitites.Models
{
    public class Player
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; } //Foreign Key
        public Team? Team { get; set; } //Navigation Property

        [StringLength(50)]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        [StringLength(100)]
        public string country { get; set; }

        public int age { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public double marketValue { get; set; }
        [StringLength(50)]
        public string position { get; set; }
        public bool isInTranferList { get; set; } = false;
        public double askedPrice { get; set; }

    }
}
