using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreForTickets.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HallId { get; set; }
        public int ArtistId { get; set; }
        public DateTime Date { get; set; }
        public int LengthOfEventInMinutes { get; set; }
        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public Ticket ticket { get; set; }
        [ForeignKey("HallId")]
        public Halls Hall { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

    }
}