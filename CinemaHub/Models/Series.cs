using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CinemaHub.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ImgSrc { get; set; }
        public string Description { get; set; } 
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        [NotMapped]
        public bool IsFavourite { get; set; }   

    }
}