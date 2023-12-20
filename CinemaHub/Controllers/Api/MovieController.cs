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
    public class MovieController : ApiController
    {


        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }




        public IEnumerable<Movie> GetMovies()
        {
            return _context.movies.Include(c => c.Genre).ToList();
        }

        [HttpGet]
        public Movie GetMovie(int id)
        {
            var movie = _context.movies.FirstOrDefault(c => c.Id == id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else

                return (movie);


        }



        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

           
            _context.movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);


        }



        [HttpPut]
        public void UpdateMovie(Movie movie, int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var MovieInDb = _context.movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            MovieInDb.Description = movie.Description;
            MovieInDb.ImgSrc = movie.ImgSrc;
            MovieInDb.VidSrc = movie.VidSrc;
            MovieInDb.Name = movie.Name;
            MovieInDb.ReleaseDate = movie.ReleaseDate;
            MovieInDb.GenreId = movie.GenreId;
            

            
            _context.SaveChanges();


        }





        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var MovieInDb = _context.movies.FirstOrDefault(c => c.Id == id);
            if (MovieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            _context.movies.Remove(MovieInDb);
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
