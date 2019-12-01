using StoreForTickets.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreForTickets.ViewModels
{
    public class HistoryVM
    {
        public List<Ticket> tickets { get; set; }
    }
}