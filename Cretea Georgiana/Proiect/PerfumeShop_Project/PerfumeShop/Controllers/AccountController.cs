﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PerfumeShop.Controllers
{
    [Route("account")]
    
    public class AccountController : Controller
    {
        
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login (string username,string password)
        {
            if (username != null && password != null && username.Equals("user1") && password.Equals("123")|| username.Equals("user2") && password.Equals("1234") || username.Equals("user3") && password.Equals("12345"))
            {
                HttpContext.Session.SetString("username", username);
                return View("Success");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }
        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}