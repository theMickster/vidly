using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Web.ViewModels;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;

namespace Vidly.Web.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyDbContext _context;

        public CustomersController()
        {
            _context = new VidlyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipTypeCode).ToList();
            return View(customers);
        }

        public ViewResult DataTablesApi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            { 
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Dob = customer.Dob;
                customerInDb.MembershipTypeCodeId = customer.MembershipTypeCodeId;
                customerInDb.EmailAddress = customer.EmailAddress;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id) ?? new Customer();

            var viewModel = new CustomerEditViewModel
            {
                Customer = customer,
                MembershipTypeCodes = _context.MembershipTypeCodes.ToList()
            };

            return View("Edit", viewModel);
        }
    }
}
