using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaHub.Controllers.Api
{
   
    public class UserController : ApiController
    {

        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }



        public IEnumerable<ApplicationUser> GetUser()
        {


            return _context.Users.Include(c=>c.Roles.SingleOrDefault().RoleId).ToList();
        }


        [HttpGet]
        public ApplicationUser GetUser(string id)
        {
            var user = _context.Users.FirstOrDefault(c=>c.Id==id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else

                return (user);


        }





    }
}
