using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Archive1.Models;
using Archive1.Models.interfases;
using database.DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;

namespace Archive1.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepositore db;
        private readonly IFileProvider fileProvider;
        private UserManager<Users> userManager;

        public GameController(IGameRepositore _db, IFileProvider _fileProvider, UserManager<Users> _us)
        {
            db = _db;
            fileProvider = _fileProvider;
            userManager = _us;
        }
        [Authorize]
        public IActionResult ViewDevelop(int id)
        {
            Game currentGame = db.Games.Include(c => c.GameDev).Include(c => c.Genre).Where(o => o.Id == id).SingleOrDefault();
            var stud = from co in db.Games
                       where co.GameDev.Id == id
                       select co.GameDev;
            return View("");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddGame()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGame(string name, string gameGenre, DateTime dateCreate, string gameDescr)
        {
            Users admin = await userManager.FindByNameAsync(User.Identity.Name);
            db.AddGame(new Game(name, gameGenre, dateCreate, gameDescr));
            return View("AddGame", String.Format("Гра \"{0}\" успішно додана!", name));
        }
       /* [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddGames()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGames(string name, string ing, DateTime dateCreate, string gameDescr)
        {
            Users admin = await userManager.FindByNameAsync(User.Identity.Name);
            db.AddGame(new Game(name, ing, dateCreate, gameDescr));
            return View("AddGames", String.Format("Гра \"{0}\" успішно додана!", name));
        }*/
    }
}
