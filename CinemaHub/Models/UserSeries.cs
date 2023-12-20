using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.Models
{
    public class UserSeries
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Series series { get; set; }
        public int SeriesId { get; set; }
    }
}