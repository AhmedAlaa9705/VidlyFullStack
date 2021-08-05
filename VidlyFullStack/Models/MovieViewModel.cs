using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Classes;
using System.ComponentModel.DataAnnotations;

namespace VidlyFullStack.Models
{
    public class MovieViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
      
        [Range(1, 10)]
        public int? NumberInStock { get; set; }
        
        [Required]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public MovieViewModel()
        {
            Id = 0;
        }
        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
            StartDate = movie.StartDate;
        }
    }
}