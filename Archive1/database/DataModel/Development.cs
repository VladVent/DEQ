using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.DataModel
{
    public class Development
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      [Required]
        public string Name { get; set; }
        public DateTime DataCreate { get; set; }
        public int Persons { get; set; }
        public Development(string _name, DateTime _dateTime, int _persons)
        {
            Name = _name;
            DataCreate = _dateTime;
            Persons = _persons;
        }
        public Development()
        { }
    }
}
