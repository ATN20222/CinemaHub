using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.ViewModels
{
    public class SeriesGenreViewModel
    {
        public IEnumerable<Genre> genre;
        public Series series { get; set; }
    }
}