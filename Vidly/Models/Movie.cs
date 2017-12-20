using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ReleaseDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}