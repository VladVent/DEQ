using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using database.DataModel;
namespace Archive1.Models.interfases
{
    public interface IGameRepositore
    {
        IQueryable<Development> Developments { get; }
        IQueryable<Game> Games { get; }
        IQueryable<Published> Publisheds { get; }
        IQueryable<Users> User { get; }
        IQueryable<LikeGame> LikeGames { get; }
    
        void AddGame(Game newGame);
        
        
    }
}
