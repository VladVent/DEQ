using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace database.DataModel
{
    public class Published
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     [Required]
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        public int QuantityProducted { get; set; }
        public  Published(string _name, DateTime _dateTime, int _quont)
        {
            Name = _name;
            DateCreate = _dateTime;
            QuantityProducted = _quont;
        }
        public Published()
        { }
    }
}
