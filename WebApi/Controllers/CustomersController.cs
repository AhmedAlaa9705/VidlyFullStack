using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Classes;
using WebApi.DTO;
using AutoMapper;
using System.Web.Http.Cors;
using System.Data.Entity;
using DataAccess.Repository;


namespace WebApi.Controllers
{
    [EnableCors(origins: "*",headers:"*",methods:"*")]
    public class CustomersController : ApiController
    {
        private IRepository<Customer> repository;
        
        public CustomersController()
        {
            repository = new Repository<Customer>(new MyContext());
            
        }
        public IEnumerable<Customer> Get()
        {
            return repository.GetAllWithInvlude("MemberShipType");
        }
           [HttpGet] 
        public IHttpActionResult GetCustomers(string MemberShipType,string query=null)
        {
            var customerQwer = repository.GetAllWithInvlude("MemberShipType");
              

            if (!String.IsNullOrWhiteSpace(query))
                customerQwer = customerQwer.Where(a => a.Name.Contains(query));

            var customerdto=customerQwer.ToList()
               .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customerdto);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cus = repository.Get(id);
            if (cus == null)
                return NotFound();
            return Ok( Mapper.Map<Customer,CustomerDto>( cus));
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            repository.Insert(customer);
            repository.Save();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }
        [HttpPut]
        public void Update(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cusInDB = repository.Get(id);
            if (cusInDB == null)
                Request.CreateResponse(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, cusInDB);
         

            repository.Save();
        }
        [HttpDelete]
        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save(); 
        }
    }
}
 