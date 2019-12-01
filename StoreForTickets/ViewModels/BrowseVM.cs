using StoreForTickets.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreForTickets.ViewModels
{
    public class BrowseVM
    {
        public List<Event> events { get; set; }
        public PurchaseHistory historyOfCurrUser { get; set; }

    }
}