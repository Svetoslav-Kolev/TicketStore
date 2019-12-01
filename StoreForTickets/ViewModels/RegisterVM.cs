using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreForTickets.ViewModels
{
    public class RegisterVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Address { get; set; }
       
    }
}