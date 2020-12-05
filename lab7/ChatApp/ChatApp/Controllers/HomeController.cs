﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private const string UserNameKey = "USER_NAME_KEY";

        [HttpGet("signin")]
        public IActionResult SignIn()
        {
            return View(new SignInVm());
        }
        [HttpPost("signin")]
        public IActionResult SignIn(SignInVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            HttpContext.Session.SetString(UserNameKey, vm.UserName);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString(UserNameKey);

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("SingIn");
            }

            ViewData["UserName"] = userName;
            return View();
        }
    }
}
