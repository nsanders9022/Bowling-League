using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportLeague.Models
{
    [Table("Teams")]
    public class Team
    {
        public Team()
        {
            this.Player = new HashSet<Player>();
        }

        [Key]
        public int teamId { get; set; }
        public string name { get; set; }
        public int divisionId { get; set; }

        public virtual ICollection<Player> Player { get; set; }

        public virtual Division Division { get; set; }
    }
}