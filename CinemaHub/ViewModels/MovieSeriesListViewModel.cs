using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.ViewModels
{
    public class MovieSeriesListViewModel
    {
        public IEnumerable<Series> series { get; set; }
        public IEnumerable<Movie> movies { get; set; }

    }
}