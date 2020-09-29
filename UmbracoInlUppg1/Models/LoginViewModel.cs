using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UmbracoInlUppg1.Models
{
    public class LoginViewModel

    {

        [Display(Name = "Username")]

        [Required]

        public string Username { get; set; }



        [Display(Name = "Password")]
        /*[DataType(DataType.Password)]*/
        [Required]

        public string Password { get; set; }

    }
}