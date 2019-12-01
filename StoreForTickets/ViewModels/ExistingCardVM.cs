using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreForTickets.ViewModels
{
    public class ExistingCardVM
    {
        public int Id { get; set; }
    
        public string CardNumber { get; set; }
   
        public string ExpiryDate { get; set; }
     
        public string Name { get; set; }
  
        public int SecurityCode { get; set; }
    }
}