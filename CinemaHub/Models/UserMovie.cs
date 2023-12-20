using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CinemaHub.Models
{
    public class UserMovie
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }



    }
}