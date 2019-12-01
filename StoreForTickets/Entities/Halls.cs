using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreForTickets.Entities
{
    public class Halls
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}