using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace CinemaHub.Controllers.Api
{

    public class SeriesController : ApiController
    {


        private ApplicationDbContext _context;
        public SeriesController()
        {
            _context = new ApplicationDbContext();
        }




        public IEnumerable<Series> GetMovies()
        {
            return _context.series.Include(c => c.Genre).ToList();
        }

        [HttpGet]
        public Series GetSeries(int id)
        {
            var series = _context.series.FirstOrDefault(c => c.Id == id);

            if (series == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else

                return (series);


        }



        [HttpPost]
        public IHttpActionResult CreateSeries(Series series)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

           
            _context.series.Add(series);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + series.Id), series);


        }



        [HttpPut]
        public void UpdateSeries(Series series, int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var SeriesInDb = _context.movies.SingleOrDefault(c => c.Id == id);

            if (SeriesInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            SeriesInDb.Description = series.Description;
            SeriesInDb.ImgSrc = series.ImgSrc;
            SeriesInDb.Name = series.Name;
            SeriesInDb.ReleaseDate = series.ReleaseDate;
            SeriesInDb.GenreId = series.GenreId;
            

            
            _context.SaveChanges();


        }





        [HttpDelete]
        public void DeleteSeries(int id)
        {
            var SeriesInDb = _context.series.FirstOrDefault(c => c.Id == id);
            if (SeriesInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            _context.series.Remove(SeriesInDb);
            _context.SaveChanges();

        }


        //
        //[HttpPost]

        //public JsonResult AddToFav(int id)
        //{
        //    var Movie = _context.movies.SingleOrDefault(c => c.Id == id);


        //    if (Movie != null)
        //    {
        //        var IdUser = User.Identity.GetUserId();
        //        var ConUser = _context.Users.Single(c => c.Id == IdUser);
        //        UserMovie userMovie = new UserMovie()
        //        {
        //            MovieId = Movie.Id,
        //            Movie = Movie,
        //            UserId = IdUser,
        //            User = ConUser


        //        };


        //        _context.UserMovies.Add(userMovie);
        //        _context.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    else
        //    {
        //        return Json(new { success = false });
        //    }

            

        //}










    }


}
