using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.ViewModels
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> genre;
        public Movie movie { get; set; }
    }
}