using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMvcApp.ViewModels;
using MovieRentalMvcApp.Models;
using System.Net.Http;

namespace MovieRentalMVCApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

         //GET: Customer
        //public ActionResult Index()
        //{
        //    var customers = _context.Customers.Include(c => c.MembershipType).ToList();
        //   return View(customers);
        //}
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
           IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57515/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
               if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
               }
               else
               {
                   customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, new Exception());
               }
           }
                return View(customers);
        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        public ActionResult New()
        {
          
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        [Authorize(Roles ="admin")]

        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customer.Id == 0)

                _context.Customers.Add(customer);
            else
            {
               var customerInDb= _context.Customers.Single(c=>c.Id==customer.Id);//link to entity.
                customerInDb.Name = customer.Name;
                customerInDb.DoB = customer.DoB;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Delete(int Id)
        {
            Customer customers = _context.Customers.Find(Id);
            _context.Customers.Remove(customers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       // public A
    }

}