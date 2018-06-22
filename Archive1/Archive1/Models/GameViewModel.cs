using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using database.DataModel;

namespace Archive1.Models
{
    public class GameViewModel
    {
        public bool? ShowRequestGame { get; set; }
        public Game CurrentGame { get; set; }
        public GameViewModel(Game _game, bool? _show)
        {
            CurrentGame = _game;
            ShowRequestGame = _show;
        }
    }
}
