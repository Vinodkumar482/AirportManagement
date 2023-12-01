using AirportManagement.Models.BussinessLayer;
using AirportManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AirportManagement.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    [TypeAuthorization("Admin")]
    public class PilotController : Controller
    {
        // GET: Pilot
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AddPilot a, string AddPilotBtn)
        {
            if (AddPilotBtn == "AddPilot")
            {
                if (ModelState.IsValid)
                {
                    string st = "";
                    AddingPilot addingPilot = new AddingPilot();
                    a = addingPilot.trim(a);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44338/api/");
                        var responseTask = client.PostAsJsonAsync<AddPilot>("Pilot/AddPilot", a);
                        responseTask.Wait();
                        var result = responseTask.Result;
                        var readData = result.Content.ReadAsAsync<string>();
                        if (result.IsSuccessStatusCode)
                        {
                            st = readData.Result;
                            ViewBag.msg = st;
                            ModelState.Clear();
                            return View();
                        }
                        else
                        {
                            st = readData.Result;
                            ViewBag.msg = st;
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.msg = "couldn't add pilot";
                    return View();
                }
            }
            else if (AddPilotBtn == "Reset")
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}