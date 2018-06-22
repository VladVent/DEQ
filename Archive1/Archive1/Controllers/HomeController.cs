using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Archive1.Models;
using Archive1.Models.interfases;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using database.DataModel;

namespace Archive1.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<Users> UserManager;
        private RoleManager<IdentityRole> RoleManager;
        private readonly IGameRepositore _context;
        public HomeController(IGameRepositore context, UserManager<Users> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            _context = context;
            UserManager = _userManager;
            RoleManager = _roleManager;
        }
        public IActionResult Index(string name = null, string category = null)
        {
            ViewData["SearchText"] = (name != null && !String.IsNullOrEmpty(name)) ? name : "";
            ViewData["SearchCategory"] = (category != null && category != "Всі ігри") ? category : "Всі ігри";
            IQueryable<Game> AllGame;
            if (name == null)
            {
                if (category != null && category != "Всі ігри")
                {
                    AllGame = _context.Games.Include(c => c.GameDev).Include(c => c.GamePub).Where(c => c.Genre == category);
                }
                else
                {
                    AllGame = _context.Games.Include(c => c.GameDev).Include(c => c.GamePub);
                }
            }
            else
            {
                if (category != null && category != "Всі ігри")
                {
                    AllGame = _context.Games.Include(c => c.GameDev).Include(c => c.GamePub).Where(s => s.Name.Contains(name)).Where(c => c.Genre == category);
                }
                else
                {
                    AllGame = _context.Games.Include(c => c.GameDev).Include(c => c.GamePub).Where(s => s.Name.Contains(name));
                }
            }
            List<GameViewModel> vm = new List<GameViewModel>();
            foreach (var gme in AllGame)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.User.IsInRole("Users"))
                    {
                        bool? show = true;
                        var acc = _context.Developments.Where(c => c.Name == HttpContext.User.Identity.Name);
                        vm.Add(new GameViewModel(gme, show));
                    }
                    else
                    {
                        vm.Add(new GameViewModel(gme, null));
                    }
                }
                else
                {
                    vm.Add(new GameViewModel(gme, null));
                }
            }
            return View(new HomeGameViewModel(vm, category));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> CreateDB()
        {
            await RoleManager.CreateAsync(new IdentityRole("Admin"));
            await RoleManager.CreateAsync(new IdentityRole("Users"));
            await RoleManager.CreateAsync(new IdentityRole("Bunned"));

            //Users
            await UserManager.CreateAsync(new Users() { UserName = "bohdan.romaniuk", Name = "Романюк Богдан"}, "123456");
            await UserManager.CreateAsync(new Users() { UserName = "roman.parobiy", Name = "Паробій Роман"}, "123456");
            await UserManager.CreateAsync(new Users() { UserName = "modest.radomskyy", Name = "Модест Радомський"}, "123456");
            await UserManager.CreateAsync(new Users() { UserName = "admin", Name = "Адміністратор"}, "123456");

            Users bohdan = await UserManager.FindByNameAsync("bohdan.romaniuk");
            Users roman = await UserManager.FindByNameAsync("roman.parobiy");
            Users modest = await UserManager.FindByNameAsync("modest.radomskyy");
            Users admin = await UserManager.FindByNameAsync("admin");

            await UserManager.AddToRoleAsync(bohdan, "Users");
            await UserManager.AddToRoleAsync(roman, "Users");
            await UserManager.AddToRoleAsync(modest, "Users");
            await UserManager.AddToRoleAsync(admin, "Admin");
            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }
    }
}
