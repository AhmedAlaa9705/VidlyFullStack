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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MoviesController : ApiController
    {
        private IRepository<Movie> repository;
       
        public MoviesController()
        {
            repository = new Repository<Movie>(new MyContext());
            
        }
        public IHttpActionResult GetMovies(string query=null)
        {
            var moviesqwery = repository.GetAllWithInvlude("Genre");

                if(!String.IsNullOrWhiteSpace(query))
                moviesqwery = moviesqwery.Where(a => a.Name.Contains(query));

                var moviesdto=moviesqwery

                .ToList()
                .Select(Mapper.Map<Movie,MovieDto>);
            return Ok(moviesdto);
        }
        public IHttpActionResult Get(int id)
        {
            var mov = repository.Get(id);
            if (mov == null)
                return NotFound();
            return Ok(Mapper.Map<Movie,MovieDto>(mov));
            
        }
        [HttpPost]
        public IHttpActionResult Create(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var mov= Mapper.Map<MovieDto, Movie>(movieDto);
            repository.Insert(mov);
            repository.Save();
            return Created(new Uri(Request.RequestUri + "/" + mov.Id), movieDto);
        }
        [HttpPut]
        public void Update(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                 Request.CreateResponse(HttpStatusCode.BadRequest);
            var movInDB = repository.Get(id);
            if (movInDB == null)
                 Request.CreateResponse(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movInDB);
            repository.Save();

        }
        public void Delete(int id)
        {
            var mov = repository.Get(id);
            if (mov == null)
                Request.CreateResponse(HttpStatusCode.NotFound);
            repository.Delete(id);
            repository.Save();
        }
    }
}
