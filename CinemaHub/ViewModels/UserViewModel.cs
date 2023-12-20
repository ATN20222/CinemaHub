using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<Movie> movies { get; set; }


    }
}