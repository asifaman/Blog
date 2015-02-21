using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Login
    {
        public string LoginId { set; get; }
        [Required]
        [Display(Name = "User Name")]
        public string Username { set; get; }

        [Required]
        [Display(Name = "Password")]
        public string Password { set; get; }

       
    }
}