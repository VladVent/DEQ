using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text;
using database.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace database
{

    public class Repository : IdentityDbContext<Users>
    {
        public DbSet<Published> Published { get; set; }
        public DbSet<Development> Develop { get; set; }

        public DbSet<Game> Games { get; set; }
        public DbSet<LikeGame> LikeGames { get; set; }
        public Repository()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(LocalDb)\MSSQLLocalDB;initial catalog=Archive1;integrated security=True;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Published>().ToTable("Published");
            modelBuilder.Entity<Development>().ToTable("Develop");

            modelBuilder.Entity<Game>().ToTable("Games");

            modelBuilder.Entity<LikeGame>().ToTable("LikeGame");
        }
        public static async Task CreateAccount(IServiceProvider serviceProvider, string login, string password, string role)
        {
            UserManager<Users> userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (await userManager.FindByNameAsync(login) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                Users user = new Users
                {
                    Login = login
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }

            }

        }
        public class Program
        {
            public static void Main(string[] args)
            {
                using (Repository db = new Repository())
                {
                     Users vlad = db.Users.Where(u => u.UserName == "Vent").SingleOrDefault();

                    //db.Games.Add(new Game("Silent Hill", "../../SH1.png", Convert.ToDateTime("07.08.1999"), "Horror","Перша частина серії Silent Hill"));
                   // db.SaveChanges();
                    //Game Silent = db.Games.Include(c => c.GameDev).Where(c => c.Name == "Silent Hill").SingleOrDefault();
                    Development dev1 = new Development("Team Silents", Convert.ToDateTime("07.08.1996"), 41);
                    Published pub1 = new Published("Konami", Convert.ToDateTime("01.05.1989"), 100);

                    //Silent.GameDev.Add(dev1);
                    //Silent.GamePub.Add(pub1);

                    // db.SaveChanges();
                    Console.WriteLine(dev1 + "        " + pub1 + "     " + "     " + db);
                }
                Console.WriteLine("Database synhronized");
                Console.ReadKey();
            }
        }
    }
}
