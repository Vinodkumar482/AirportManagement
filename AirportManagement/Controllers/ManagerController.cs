﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportManagement.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Home()
        {
            return View();
        }
    }
}