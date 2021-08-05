using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Classes
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndtDate { get; set; }
        [Range(1,10)]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }
        public int NumberAvailable { get; set; }

    }
}
