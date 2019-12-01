using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreForTickets.Entities
{
    public class CardInfo
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        private string expiryDate;
        public string Name { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int securityCode { get; set; }
        public string ExpiryDate
        {
            get { return expiryDate; }
            set
            {
                int[] input = value.ToString().Split('/').Select(int.Parse).ToArray();
                string currentDate = DateTime.Now.Year.ToString();
                string currentDateLastTwo = $"{currentDate[2]}{currentDate[3]}";
                if (int.Parse(currentDateLastTwo) > input[1])
                {
                    throw new ArgumentException("Your card has expired");
                }
                else
                {
                    expiryDate = value;
                }

            }
        }


    }
}