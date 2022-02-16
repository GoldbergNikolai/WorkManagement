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
        private readonly ILogger<HomeController> _logger;
        private IUsersService _userService = new UsersService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogInPage() => View();

        [HttpPost]
        public JsonResult LogIn(string phoneNumber)
        {
            SessionHelper.SessionUser = null;
            var response = _userService.CheckIfUserExists(phoneNumber);

            if (response.Data != null && response.Data.UserId > 0 && response.Data.Active)
            {
                var user = response.Data;
                SessionHelper.SessionUser = new User
                {
                    UserId = user.UserId,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Active = user.Active,
                    IsAdmin = user.IsAdmin
                };
            }

            return new JsonResult(response ?? new ResponseViewModel<UserViewModel>());
        }

        public IActionResult LogOut()
        {
            SessionHelper.SessionUser = null;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
