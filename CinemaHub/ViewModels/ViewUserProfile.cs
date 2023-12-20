using CinemaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CinemaHub.ViewModels
{
    public class ViewUserProfile
    {
        public ChangePasswordViewModel ChangePassword { get; set; }
        public ApplicationUser user { get; set; }
    }
}