using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=> c.MemberShipType).ToList();
            return View(customers);
        }


        public ActionResult Details(int Id)
        {
            Customer customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }

        public ActionResult New()
        {
            var viewModel = new CustomerViewModel
            {
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerUpdate = _context.Customers.Single(c=> c.Id == customer.Id);

                customerUpdate.Name = customer.Name;
                customerUpdate.BirthDate = customer.BirthDate;
                customerUpdate.MemberShipTypeId = customer.MemberShipTypeId;
                customerUpdate.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int Id)
        {
            Customer customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                
                return View("CustomerForm", viewModel);
            }
        }
    }
}