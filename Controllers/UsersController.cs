﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Models;
using WorkManagement.Models.Shared;
using WorkManagement.Users.Models;
using WorkManagement.Users.Services;

namespace WorkManagement.Controllers
{
    public class UsersController : Controller
    {
        #region Private Members

        private IUsersService _userService = new UsersService();

        #endregion


        #region Controllers

        [HttpDelete]
        public ActionResult DeleteUser(int userId)
        {
            var response = _userService.DeleteUser(userId);

            return new JsonResult(response ?? new ResponseViewModel<bool>());
        }

        [HttpGet]
        public ActionResult UsersPage() => View();

        [HttpGet]
        public ActionResult SearchUsers() => View();

        [HttpGet]
        public ActionResult GetUsers (int? userId = null, string phoneNumber = null, bool? active = null, bool? isAdmin = null, int? top = null, bool bringAll = false)
        {
            var response = new ResponseViewModel<List<UserViewModel>>();

            if (bringAll || userId != null || phoneNumber != null || active != null || isAdmin != null)
            {
                response = _userService.GetUsers(userId, phoneNumber, active, isAdmin, top, bringAll);
            }

            return new JsonResult (response ?? new ResponseViewModel<List<UserViewModel>>());
        }

        [HttpGet]
        public ActionResult InsertUser() => View();

        [HttpPost]
        public ActionResult InsertUser (string phoneNumber, string firstName, string lastName)
        {
            var response = _userService.InserUser(phoneNumber, firstName, lastName);

            return new JsonResult(response ?? new ResponseViewModel<int>());
        }

        [HttpPatch]
        public ActionResult UpdateUser(string phoneNumber, string firstName, string lastName)
        {
            var response = _userService.UpdateUser(phoneNumber, firstName, lastName);

            return new JsonResult(response ?? new ResponseViewModel<bool>());
        }

        public ActionResult UpdateUserActivationState (int userId, bool active)
        {
            var response = _userService.UpdateUserActivationState(userId, active);

            return new JsonResult(response ?? new ResponseViewModel<bool>());
        }

        public ActionResult UpdateAdminState(int userId, bool isAdmin)
        {
            var response = _userService.UpdateAdminState(userId, isAdmin);

            return new JsonResult(response ?? new ResponseViewModel<bool>());
        }

        #endregion

        //TODO: Remove
        //// GET: UsersController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: UsersController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: UsersController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: UsersController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UsersController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UsersController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UsersController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UsersController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
