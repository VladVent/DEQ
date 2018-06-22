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
namespace Archive1.Controllers
{
    public class AdminController : Controller
    {
        private IGameRepositore db;
        private UserManager<Users> userManager;
        public AdminController(IGameRepositore _db, UserManager<Users> _userManager)
        {
            userManager = _userManager;
            db = _db;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetTeacher(string name)
        {
            Users users = db.User.Where(u => u.UserName == name).SingleOrDefault();
            await userManager.RemoveFromRoleAsync(users, "Users");
            await userManager.AddToRoleAsync(users, "Bunned");
            return RedirectToRoute(new { controller = "Profile", action = "View", name = name });
        }


    }
}
