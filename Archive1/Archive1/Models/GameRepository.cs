using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Archive1.Models.interfases;
using database.DataModel;
namespace Archive1.Models
{
    public class GameRepository : IGameRepositore
    {
        private GameDatabase context;
        public GameRepository(GameDatabase gd)
        {
            context = gd;
        }

        public IQueryable<Development> Developments => context.Develop;
        public IQueryable<Game> Games => context.Game;
        public IQueryable<Published> Publisheds => context.Published;
        public IQueryable<Users> User => context.Users;
        public IQueryable<LikeGame> LikeGames => context.LikeGame;
        
        public void AddGame(Game newGame)
        {
            context.Game.Add(newGame);
            context.SaveChanges();
        }
      
        //public void DeleteCourse(int id)
        //{
        //    Game game = context.Game.Include(c => c.GameDev).ThenInclude(l => l.).Where(c => c.Id == courseId).SingleOrDefault();
        //    var listeners = context.CoursesListeners.Where(c => c.RequestedCourse.Id == courseId);
        //    foreach (var l in listeners)
        //    {
        //        context.CoursesListeners.Remove(l);
        //    }
        //    foreach (var l in course.CourseLessons)
        //    {
        //        foreach (var p in l.Posts)
        //        {
        //            context.Posts.Remove(p);
        //        }
        //        context.Lessons.Remove(l);
        //    }
        //    context.Remove(course);
        //    context.SaveChanges();
        //}
    }
}
