using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace CinemaHub.Controllers
{
    [Authorize(Roles = "User,!Admin")]

    public class FilmController : Controller
    {
        private ApplicationDbContext _context;
        public FilmController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Film
        public ActionResult Index(int id)
        {
            var movie = _context.movies.Include(c=>c.Genre).Single(c=>c.Id==id);

            return View();
        }


        public ActionResult WatchingMovie(int id)
        {
            var movie = _context.movies.Include(s => s.Genre).SingleOrDefault(c => c.Id == id);


            return View(movie);
        }
    }
}