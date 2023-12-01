using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportManagement.Controllers
{
    [TypeAuthorization("Admin")]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }
    }
}