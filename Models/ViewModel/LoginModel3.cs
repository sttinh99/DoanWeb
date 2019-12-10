using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestCase.Models.ViewModel
{
    public class LoginModel3
    {
        [Required(ErrorMessage = "Please type UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please type PassWord")]
        public string Password { get; set; }
    }
}
