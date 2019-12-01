using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreForTickets.ViewModels
{
    public class RegisterCardVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string ExpiryDate { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int SecurityCode { get; set; }
    }
}