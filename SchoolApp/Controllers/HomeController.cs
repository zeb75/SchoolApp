﻿using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolApp.Controllers
{
    public class HomeController : Controller
    { 
         SchoolAppDbContext db = new SchoolAppDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();

        }
    }
}