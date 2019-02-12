using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI.Models
{

    public class AdminSpecialViewModel
    {
        public Specials Special { get; set; }
        public List<Specials> SpecialsList { get; set; }
    }

    public class UsersListViewModel
    {
        public List<UserWithRole> Users { get; set; }
    }

    public class UserWithRole
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string ID { get; set; }
    }
}