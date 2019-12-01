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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           
            IndexVM model = new IndexVM();
       
            return View(model);
        }
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                TicketStoreContext context = new TicketStoreContext();

                User loggedUser = context.users.Where(u => u.Username == model.Username 
                && u.Password == model.Password)
                .FirstOrDefault();

                if (loggedUser != null)
                {
                    Session["loggedUser"] = loggedUser;
                  
                }
                else 
                {
                    return View(model);
                }
                return RedirectToAction("Index", "Users");
            }
            else
            {
                return View(model);
            }
            //send to user view
          

        }
       
       
      public ActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            TicketStoreContext context = new TicketStoreContext();

            User user = new User();
            user.Id = model.Id;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Address = model.Address;
            if (user.Id <= 0)
            {
                if(context.histories.Where(h=>h.Id == user.Id) == null)
                {
                    var history = new PurchaseHistory();
                    history.UserId = user.Id;
                    history.tickets = new List<Ticket>();
                    context.histories.Add(history);
                }
                context.users.Add(user);
            }
            else
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
            return RedirectToAction("Login" , "Home");
        }
    }
}