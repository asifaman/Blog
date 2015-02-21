using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class Register
    {
        public string RegisterId { set; get; }

        [Required]
        [Display(Name = "User Name")]
        //[Remote("MedicineCheck", "HeadOffice", HttpMethod = "POST", ErrorMessage = "The Username Already Taken. Please Select Another Username!!")]
        public string Username { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { set; get; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}