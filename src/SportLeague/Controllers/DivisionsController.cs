using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportLeague.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportLeague.Controllers
{
    public class DivisionsController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueContext db = new SportsLeagueContext();
        public IActionResult Index()
        {
            
            return View(db.Divisions.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.divisionId == id);
            return View(thisDivision);
        }



    }
}
