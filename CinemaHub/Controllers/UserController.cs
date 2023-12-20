using CinemaHub.Models;
using CinemaHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaHub.Controllers
{

 
    public class UserController : Controller
    {


        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [Authorize(Roles = "User,!Admin")]

        // GET: User
        public ActionResult Index(ChangePasswordViewModel model)
        {
            TempData["User"] = "active";
            TempData["ShowError"] = "false";
            var user=User.Identity.GetUserId();
            var us = _context.Users.SingleOrDefault(c => c.Id == user);

            var ViewModel = new ViewUserProfile
            {
               
               
            };


            if (model.NewPassword == null && model.OldPassword == null&& model.ConfirmPassword == null)
            {
                TempData["ShowError"] = "True";
                ViewModel = new ViewUserProfile
                {
                    user = us,
                    ChangePassword= new ChangePasswordViewModel(),
                   
                };
            }
            else
            {

                ViewModel = new ViewUserProfile
                {
                    user = us,
                    ChangePassword = model

                };
            }
            return View(ViewModel);
        }



    }
}