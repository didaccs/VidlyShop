using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [DisplayName("Movie")]
        [Required]
        public String Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [ForeignKey("Genre")]
        [Required]
        public int GenreId { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Added Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        [Required]
        [Range(1, 20, ErrorMessage = "The number of movies in stock must be between 1 and 20.")]
        public int NumberInStock { get; set; }
    }
}