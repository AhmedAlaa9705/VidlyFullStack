using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Classes;
using System.Data.Entity;
using VidlyFullStack.Models;
using System.Data.Entity.Validation;
using DataAccess.Repository;

namespace VidlyFullStack.Controllers
{
    public class MoviesController : Controller
    {
        private IRepository<Movie> repository;
        private IRepository<Genre> Genrerepos;
        
        public MoviesController()
        {

            repository = new Repository<Movie>(new MyContext());
            Genrerepos = new Repository<Genre>(new MyContext());
        }
        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanMangeMovie))
            {
                return View("Index");

            }
            else
            {
                return View("readonly");
            }
        }

        [Authorize(Roles =RoleName.CanMangeMovie)]
        public ActionResult Edit(int id)
        {
            ViewBag.mv = "Update Movie";
            var mov = repository.Get(id);
            MovieViewModel viewModel = new MovieViewModel(mov)
            {
              
                Genres = Genrerepos.GetAll()

            };
            return View("MovieForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanMangeMovie)]
        public ActionResult New()
        {
            ViewBag.mv = "New Movie";
            MovieViewModel viewModel = new MovieViewModel
            {

                Genres = Genrerepos.GetAll()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                MovieViewModel viewModel = new MovieViewModel(movie)
                {
                    
                    Genres= Genrerepos.GetAll()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id==0)
            {
               repository.Insert(movie);

            }
            else
            {
                var mv = repository.GetExpre(a => a.Id == movie.Id);
                mv.Name = movie.Name;
                mv.NumberInStock = movie.NumberInStock;
                mv.StartDate = movie.StartDate;
                mv.GenreId = movie.GenreId;
                

            }
            repository.Save();
          
       
            return RedirectToAction("Index", "Movies");

        }
        
    }
}