using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Classes;
using System.Data.Entity;
using VidlyFullStack.Models;
using DataAccess.Repository;

namespace VidlyFullStack.Controllers
{
    public class CustomersController : Controller
    {
        
        private IRepository<Customer> repository;
        private IRepository<MemberShipType> memberrepository;
        public CustomersController()
        {
            repository = new Repository<Customer>(new MyContext());
            memberrepository = new Repository<MemberShipType>(new MyContext());
           
        }
        //public ActionResult Search(string S)
        //{
        //    var customer = db.Customers.Where(a=>a.Name.StartsWith(S)).Include(a => a.MemberShipType).ToList();
        //    return View("Index", customer);

        //}
        // GET: Customers
        public ActionResult Index()
        {
         
            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var cus = repository.GetInclude(a => a.Id == id, "MemberShipType");
        

            return View(cus);
        }
        [HttpGet]
        public ActionResult New()
        {
            ViewBag.cs = "New Customer";
            var member= memberrepository.GetAll();
            CustomerViewModel viewModel = new CustomerViewModel
            {
                Customer=new Customer(),
                MemberShipTypes = member
            }; 
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                CustomerViewModel viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    MemberShipTypes =memberrepository.GetAll()
                
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                repository.Insert(customer);

            }
            else
            {
                var cusindb = repository.GetInclude(a => a.Id == customer.Id, "MemberShipType");
                cusindb.Name = customer.Name;
                cusindb.Birthdate = customer.Birthdate;
                cusindb.MemberShipTypeId = customer.MemberShipTypeId;
                cusindb.IsSubscribe = customer.IsSubscribe;
            }
            repository.Save();
            return RedirectToAction("Index","Customers");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.cs = "Edit Customer";
            var cus = repository.GetInclude(a => a.Id == id, "MemberShipType");
            CustomerViewModel viewModel = new CustomerViewModel
            {
                Customer=cus,
                MemberShipTypes=memberrepository.GetAll()
            };
            return View("CustomerForm", viewModel);
        }
    }
}