using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase.Areas.Guest.Models
{
    public class LoginModel1
    {
        [Required(ErrorMessage = "Please type UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please type PassWord")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
