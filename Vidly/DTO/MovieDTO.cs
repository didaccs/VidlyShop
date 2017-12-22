using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        
        [Required]
        [Range(1, 20, ErrorMessage = "The number of movies in stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }
    }
}