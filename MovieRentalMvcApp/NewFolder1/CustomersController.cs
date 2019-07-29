using MovieRentalMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalMvcApp.NewFolder1
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Get   /api/Customers



        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
        //Get  /api/Customers/Id

        public Customer FindCustomerById(int? id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }



        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok (customer);
        }




        [HttpPut]
      
        public void updateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerIndb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerIndb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerIndb.Name = customer.Name;
            customerIndb.DoB = customer.DoB;
            customerIndb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
