using MambaWeb.DAL;
using MambaWeb.Models;
using MambaWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MambaWeb.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            Team team1 = new Team()
            {
                Fullname = "Eli ELiyev",
                Profession = "developer",
                ImgUrl= "assets/img/team/team-1.jpg"
            };
            Team team2 = new Team()
            {
                Fullname = "Aysel Babayeva",
                Profession = "designer",
                ImgUrl= "assets/img/team/team-2.jpg"
            };
            Team team3 = new Team()
            {
                Fullname = "Nicat Ehmedov",
                Profession = "enginer",
                ImgUrl= "assets/img/team/team-3.jpg"
            };
            Team team4 = new Team()
            {
                Fullname = "Sultan Rustemova",
                Profession = "Chef",
                ImgUrl= "assets/img/team/team-4.jpg"
            };

            List<Team> teams = new List<Team>();
            
               teams.Add(team1);
               teams.Add(team2);
               teams.Add(team3);
               teams.Add(team4);

            HomeVM homeVM = new HomeVM()
            {
                Teams = teams
            };
            return View(homeVM);
        }

            
    }

        
    
}
