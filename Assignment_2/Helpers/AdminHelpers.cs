using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.Models;

namespace Assignment_2.Helpers
{
    public class AdminHelpers
    {
        public void GetAllUsers()
        {
            var a = new Models.ApplicationDbContext();
            a.Users.ToList();
        }

     
    }
}