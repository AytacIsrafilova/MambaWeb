using MambaWeb.DAL;
using MambaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MambaWeb.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        AppDbContext _dbContext;

        public TeamController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Team> teams = _dbContext.Teams.Include(x => x.teams).ToList();

            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var team = _dbContext.Teams.FirstOrDefault(x => x.Id == id);
            if (team == null)
            {
                return RedirectToAction("Index");
            }

            return View(team);


        }

        [HttpPost]
        public IActionResult Update(Team newTeam)
        {
            var oldTeam = _dbContext.Teams.FirstOrDefault(x => x.Id == newTeam.Id);
            if (oldTeam == null)
            {
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            oldTeam.Fullname = newTeam.Fullname;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
