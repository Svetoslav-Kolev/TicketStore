using StoreForTickets.Entities;
using StoreForTickets.Models;
using StoreForTickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreForTickets.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult Browse()
        {
            TicketStoreContext context = new TicketStoreContext();
            BrowseVM model = new BrowseVM();
            model.events = context.events.ToList();
            User currUser = (User)Session["loggedUser"];
            model.historyOfCurrUser = context.histories.Where(h => currUser.Id == h.UserId).FirstOrDefault();
            foreach ( var currEvent in model.events)
            {
                currEvent.Hall = context.halls.Where(h => h.Id == currEvent.HallId).FirstOrDefault();
                currEvent.Artist = context.artists.Where(h => h.Id == currEvent.ArtistId).FirstOrDefault();
                currEvent.ticket = context.tickets.Where(t => t.Id == currEvent.TicketId).FirstOrDefault();
            }
            return View(model);
        }
        public ActionResult History()
        {
            TicketStoreContext context = new TicketStoreContext();
            HistoryVM model = new HistoryVM();
            User currUser = (User)Session["loggedUser"];
            List<Ticket> ticketsBought = context.histories.Where(h => h.UserId == currUser.Id).FirstOrDefault().tickets;
            model.tickets = ticketsBought;
            if(ticketsBought != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index" , "Users");
            }
           
        }
        [HttpGet]
        public ActionResult BuyTicket(int? eventId)
        {
            //Model.historyOfCurrUser.tickets.Add(item.ticket)
            TicketStoreContext context = new TicketStoreContext();
            User currUser = (User)Session["loggedUser"];
            Ticket currEventTicket = context.events.Where(e => e.Id == eventId).FirstOrDefault().ticket;
            PurchaseHistory historyOfCurrUser = context.histories.Where(h => h.UserId == currUser.Id).FirstOrDefault();
            historyOfCurrUser.tickets.Add(currEventTicket);
            return RedirectToAction("Index", "Users");
        }
        public ActionResult Card(RegisterCardVM model)
        {
            TicketStoreContext context = new TicketStoreContext();
            User currUser = (User)Session["loggedUser"];
            CardInfo currUserCard = context.cards.Where(c => c.UserId == currUser.Id).FirstOrDefault();
            if (currUserCard == null)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                CardInfo card = new CardInfo();
                card.Id = model.Id;
                card.CardNumber = model.CardNumber;
                card.Name = model.Name;
                card.UserId = currUser.Id;
                card.ExpiryDate = model.ExpiryDate;
                card.securityCode = model.SecurityCode;
                context.cards.Add(card);
                context.SaveChanges();
                return RedirectToAction("Index", "Users");
            }
            else
            {


                return RedirectToAction("UserCards", "Users");
            }
        }
        public ActionResult UserCards()
        {
            TicketStoreContext context = new TicketStoreContext();
            ExistingCardVM existingCardModel = new ExistingCardVM();
            User currUser = (User)Session["loggedUser"];
            CardInfo currUserCard = context.cards.Where(c => c.UserId == currUser.Id).FirstOrDefault();
            existingCardModel.CardNumber = currUserCard.CardNumber;
            existingCardModel.Name = currUserCard.Name;
            existingCardModel.SecurityCode = currUserCard.securityCode;
            existingCardModel.ExpiryDate = currUserCard.ExpiryDate;
            return View(existingCardModel);
        }

    }
}