using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace database.DataModel
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Img { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public string Genre{ get; set; }
        public Development GameDev { get; set; }
        public Published GamePub { get; set; }
        public Game()
        {

        }

        public Game(string _name, string _img,  DateTime _dateTime,  string _descr)
        {
            Name = _name;
            Img = _img;
            DateCreate = _dateTime;
        
            Description = _descr;
        }
    }
}
