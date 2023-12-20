using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public Series Series { get; set; }
        public int SeriesId { get; set; }
        public string VidSrc { get; set; }

    }
}