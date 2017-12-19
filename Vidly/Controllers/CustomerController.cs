using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        List<Customer> listCustomers;

        public CustomerController()
        {
            listCustomers = new List<Customer>();
            listCustomers.Add(new Customer() { Id = 1, Name = "Pau" });
            listCustomers.Add(new Customer() { Id = 2, Name = "Marc" });
        }


        // GET: Customer
        public ActionResult Index()
        {
            return View(listCustomers);
        }


        public ActionResult Details(int Id)
        {
            Customer customer = listCustomers.Find(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }            
        }
    }
}