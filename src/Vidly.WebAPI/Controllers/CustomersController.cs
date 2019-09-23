using System;
using System.Data.Entity;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.WebAPI.Dtos;
using Vidly.DataServices.DbContexts;
using Vidly.DataServices.Models;

namespace Vidly.WebAPI.Controllers
{
    /// <summary>
    /// Our API methods to perform actions on Customer DTOs.
    /// </summary>
    public class CustomersController : ApiController
    {
        private readonly VidlyDbContext _context;

        /// <summary>
        /// ....
        /// </summary>
        public CustomersController()
        {
            _context = new VidlyDbContext();
        }

        /// <summary>
        /// Call this API method to retrieve a list of all customers. 
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipTypeCode)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        /// <summary>
        /// Call this API method to retrieve a single customer by Id. 
        /// </summary>
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .Include(c=> c.MembershipTypeCode)
                .SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        /// <summary>
        /// Call this API method to create a single customer
        /// </summary>
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        /// <summary>
        /// Call this API method to update a single customer
        /// </summary>
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();

        }

        /// <summary>
        /// Call this API method to delete a single customer
        /// </summary>
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
