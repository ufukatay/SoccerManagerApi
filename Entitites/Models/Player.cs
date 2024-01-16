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
        public int? TeamId { get; set; } //Foreign Key
        public Team? Team { get; set; } //Navigation Property
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(50)]
        public string country { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public double marketValue { get; set; }
        [Required]
        [StringLength(50)]
        public string position { get; set; }
    }
}
