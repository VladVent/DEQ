using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace database.DataModel
{
    public class Users : IdentityUser
    {
       [Required]
        public string Name { get; set; }
        public string Login { get; set; }
    }
}
