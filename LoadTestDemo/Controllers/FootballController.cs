using System;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using LoadTestDemo.Models;

namespace LoadTestDemo.Controllers
{
    [Authorize]
    public class FootballController : Controller
    {
        private readonly ITeamRepository _repository;

        public FootballController()
        {
            _repository = new TeamRepository(); //would be injected with IoC if this were a real app
        }

        public ActionResult Index()
        {
            var team = _repository.GetByUser(User.Identity.Name);
            return View(team);
        }

        public ActionResult Player(string name)
        {
            var team = _repository.GetByUser(User.Identity.Name);
            var player = team.Players.Single(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return View(player);
            //throw new HttpException(404, "HTTP/1.1 404 Not Found");
        }
    }
}