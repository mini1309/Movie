using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalMvcApp.Models
{
    public class Movie
    {
        public int Id{ get; set; }

        public string MovieName { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int CdStock { get; set; }

        public Genre Genre { get; set; }
    }
}