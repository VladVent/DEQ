using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.DataModel
{
    public class LikeGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Users User { get; set; }
        public Game Games { get; set; }
        public LikeGame()
        { }
        public LikeGame(Users _users, Game _game)
        {
            User = _users;
            Games = _game;
        }
    }
}
