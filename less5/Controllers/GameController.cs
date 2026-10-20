using Microsoft.AspNetCore.Mvc;
using less5.Models;
namespace less5.Controllers
{
    public class GameController : Controller
    {
        public readonly static List<Game> Games = new List<Game>();
        
        public IActionResult Index()
        {
            return View(Games);
        }
        [HttpGet]
        public IActionResult Index(string Search)
        {
            var foundGames = Games.Where(x=>x.Genre == Search).ToList();
            return View(foundGames);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var foundGame = Games.FirstOrDefault(x=>x.Id == id);
            Games.Remove(foundGame!);
            return View("Index",Games );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Game game)
        {
            game.Id = Games.Count;
            Games.Add(game);
            return View("Index", Games);
        }
        public IActionResult Details(int id) {
            var game = Games.FirstOrDefault(x => x.Id == id);
            if (game is null)
            {
                return View("Error", "Oops, we can't find this game. Try again another time!");
            }
            return View(game);
        }
        public IActionResult Completed()
        {
            var foundGames = Games.Where(x => x.IsCompleted == true).ToList();
            return View(foundGames);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool isCompleted)
        {
            var game = Games.FirstOrDefault(g => g.Id == id);

            if (game != null)
            {
                game.IsCompleted = isCompleted;
            }

            return View("Index", Games);
        }
        public IActionResult BackToIndex()
        {
            return View("Index", Games);
        }
    }
}
