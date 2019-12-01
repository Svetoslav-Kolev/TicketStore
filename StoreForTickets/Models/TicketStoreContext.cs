using StoreForTickets.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoreForTickets.Models
{
    public class TicketStoreContext : DbContext
    {

        public DbSet<User> users { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Artist> artists { get; set; }
        public DbSet<Halls> halls { get; set; }
        public DbSet<PurchaseHistory> histories { get; set; }
        public DbSet<CardInfo> cards { get; set; }

        public TicketStoreContext() : base("Server=DESKTOP-1ADSAV1\\SQLEXPRESS;Database=StoreForTickets;Trusted_Connection=True;")
        {
            users = this.Set<User>();
            events = this.Set<Event>();
            tickets = this.Set<Ticket>();
            artists = this.Set<Artist>();
            halls = this.Set<Halls>();
            histories = this.Set<PurchaseHistory>();
            cards = this.Set<CardInfo>();
        }
    }
}