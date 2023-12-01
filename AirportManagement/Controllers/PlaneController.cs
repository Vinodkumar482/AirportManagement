using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirportManagement.Models.Entities;
using AirportManagement.Models.BussinessLayer;

namespace AirportManagement.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    [TypeAuthorization("Admin")]
    public class PlaneController : Controller
    {
        // GET: Plane
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [TypeAuthorization("Admin")]
        public ActionResult Index(AddPlane ap, string PlaneBtn)
        {
            if (PlaneBtn == "AddPlane")
            {
                if (ModelState.IsValid)
                {
                    string st = "";
                    AddingPlane addingPlane = new AddingPlane();
                    ap = addingPlane.trim(ap);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44338/api/");
                        var responseTask = client.PostAsJsonAsync<AddPlane>("Planes/AddPlane", ap);
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
                            ModelState.Clear();
                            return View();
                        }
                    }
                }
                else
                {
                    ViewBag.msg = "couldn't add Plane";
                    ViewBag.err = true;
                    return View();
                }
            }
            else if (PlaneBtn == "Reset")
            {
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult CheckingMail(string email)
        {
            Address address = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44338/api/");
                var responseTask = client.GetAsync("Planes/GetAddress?email=" + email);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readdata = result.Content.ReadAsAsync<Address>();
                    readdata.Wait();
                    address = readdata.Result;





                    if (address != null)
                    {
                        return Json(address);
                    }
                    else
                    {
                        return Json(null);
                    }
                }
                else
                {
                    return Json(null);
                }
            }
        }
    }
}