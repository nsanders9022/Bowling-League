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
    public class TeamsController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueContext db = new SportsLeagueContext();
        public IActionResult Index()
        {

            return View(db.Teams.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.Include(teams => teams.Player).Include(teams => teams.Division).FirstOrDefault(teams => teams.teamId == id);
            return View(thisTeam);
        }

        public IActionResult Create()
        {
            ViewBag.divisionId = new SelectList(db.Divisions, "divisionId", "description");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.teamId == id);
            return View(thisTeam);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.teamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

         public IActionResult Edit(int id)
        {
            ViewBag.divisionId = new SelectList(db.Divisions, "divisionId", "description");
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.teamId == id);
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
