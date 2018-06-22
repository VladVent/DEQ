using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Archive1.Models
{
    public class HomeGameViewModel
    {
        public string Category { get; set; }
        public IEnumerable<GameViewModel> Game { get; set; }
        public HomeGameViewModel(IEnumerable<GameViewModel> _game, string _category)
        {
            Category = _category;
            Game = _game;
        }
    }
}
