using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreForTickets.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

    }
}