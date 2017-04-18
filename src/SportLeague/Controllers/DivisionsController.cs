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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Division division)
        {
            db.Divisions.Add(division);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.divisionId == id);
            return View(thisDivision);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.divisionId == id);
            db.Divisions.Remove(thisDivision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
