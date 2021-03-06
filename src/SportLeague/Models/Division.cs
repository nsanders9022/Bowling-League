﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportLeague.Models
{
    [Table("Divisions")]
    public class Division
    {
        public Division()
        {
            this.Team = new HashSet<Team>();
        }

        [Key]
        public int divisionId { get; set; }
        public string skill_level { get; set; }
        public int max_team { get; set; }
        public string description { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
