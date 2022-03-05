using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStoreFix.ViewModels
{
    public class LoginFormViewModel
    {
        [Required(ErrorMessage = "this field is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}