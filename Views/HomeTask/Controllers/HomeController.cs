using HomeTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.Controllers
{
    public class HomeController : Controller
    {
        private List<UserModel> users = new List<UserModel>
        {
            new UserModel { IsDarkSide = true, PersonInfo = "Sith" },
            new UserModel { IsDarkSide = false, PersonInfo = "Wookies" }
        };

        // GET: Home
        public ActionResult Index()
        {
            return View("Person", users[1]);
        }

        public ActionResult ChangeSide(bool? side)
        {
            if(side.HasValue)
            {
                return View("Person", side.Value ? users[1] : users[0]);
            }
            else
            {
                return View("Person", users[1]);
            }
        }
    }
}