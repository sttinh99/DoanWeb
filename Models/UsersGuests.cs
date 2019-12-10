using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase.Models
{
    public class UsersGuests
    {


        [Key]
        
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please type UserName")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Please type PassWord")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Please type Name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please type Email")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Please type Phone")]
        public string Phone { get; set; }
        public string Role { get; set; }

    }
}
