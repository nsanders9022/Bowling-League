using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportLeague.Models
{
    [Table("Players")]
    public class Player
    { 

        [Key]
        public int playerId { get; set; }
        public string name { get; set; }
        public int teamId { get; set; }
        public virtual Team Team { get; set; }

    }
}