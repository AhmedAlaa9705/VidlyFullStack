using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndtDate { get; set; }
        [Range(1, 10)]
        public int NumberInStock { get; set; }
        [Required]
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }

    }
}