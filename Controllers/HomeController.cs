using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Models;
using WorkManagement.Models.Shared;
using WorkManagement.Users.Models;
using WorkManagement.Users.Services;

namespace WorkManagement.Controllers
{
    public class HomeController : Controller
    {
        #region Private Members

        private readonly ILogger<HomeController> _logger;
        private IUsersService _userService = new UsersService();

        #endregion


        #region Constructors

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion


        #region Public Methods

        public IActionResult Index() => View(GetSession());
        public IActionResult Privacy() => View(GetSession());

        [HttpGet]
        public IActionResult LogInPage() => View(GetSession());

        [HttpPost]
        public JsonResult LogIn(string phoneNumber)
        {
            var response = _userService.CheckIfUserExists(phoneNumber);
            if (response.Data != null && response.Data.UserId > 0 && response.Data.Active)
            {
                var user = response.Data;
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetInt32("Active", user.Active ? 1 : 0);
                HttpContext.Session.SetInt32("IsAdmin", user.IsAdmin ? 1 : 0);
                HttpContext.Session.SetString("FirstName", user.FirstName);
                HttpContext.Session.SetString("LastName", user.LastName);
            }

            return new JsonResult(response ?? new ResponseViewModel<UserViewModel>());
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.SetInt32("UserId", 0);
            HttpContext.Session.SetInt32("Active", 0);
            HttpContext.Session.SetInt32("IsAdmin", 0);
            HttpContext.Session.SetString("FirstName",null);
            HttpContext.Session.SetString("LastName", null);

            return View("Index", GetSession());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion


        #region Private Methods

        public SessionHelper GetSession()
        {
            var session = new SessionHelper();

            if(HttpContext.Session.Keys.Any())
            {
                session.UserId = (int)HttpContext.Session.GetInt32("UserId");
                session.Active = (int)HttpContext.Session.GetInt32("Active") == 1;
                session.IsAdmin = (int)HttpContext.Session.GetInt32("IsAdmin") == 1;
                session.FirstName = HttpContext.Session.GetString("FirstName");
                session.LastName = HttpContext.Session.GetString("LastName");
            }

            return session;
        }

        #endregion
    }
}
