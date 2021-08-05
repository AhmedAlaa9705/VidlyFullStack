using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DTO;
using DataAccess.Classes;
namespace WebApi.Controllers
{
    public class NewRentalController : ApiController
    {
        private MyContext db;
        public NewRentalController()
        {
            db = new MyContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {
          

            var customer = db.Customers.Single(a => a.Id == newRental.CustomerId);


            var movies = db.Movies.Where(a => newRental.MovieIds.Contains(a.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is Not Avalible");
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                db.Rentals.Add(rental);
            }
            db.SaveChanges();
            return Ok();
        }
    }
}
