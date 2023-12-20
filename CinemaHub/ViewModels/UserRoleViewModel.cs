using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaHub.ViewModels
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Roles { get; set; }
    }
}