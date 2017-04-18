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
    public class PlayersController : Controller
    {
        // GET: /<controller>/
        private SportsLeagueContext db = new SportsLeagueContext();
        public IActionResult Index()
        {

            return View(db.Players.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.playerId == id);
            return View(thisPlayer);
        }

        public IActionResult Create()
        {
            ViewBag.teamId = new SelectList(db.Teams, "teamId", "name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.playerId == id);
            return View(thisPlayer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.playerId == id);
            db.Players.Remove(thisPlayer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.teamId = new SelectList(db.Teams, "teamId", "name");
            var thisPlayer = db.Players.FirstOrDefault(players => players.playerId == id);
            return View(thisPlayer);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
