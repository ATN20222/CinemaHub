using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.ViewModels
{
    public class SeriesEpisodeViewModel
    {
        public IEnumerable<Episode> episodes;
        public Series series { get; set; }


    }
}