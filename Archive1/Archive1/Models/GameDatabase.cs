using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using database.DataModel;
namespace Archive1.Models
{
    public class GameDatabase : IdentityDbContext<Users>
    {
        public DbSet<Published> Published { get; set; }
        public DbSet<Development> Develop { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<LikeGame> LikeGame { get; set; }
       
        public GameDatabase(DbContextOptions<GameDatabase> options) :
            base(options)
        {
        }

    }
}
