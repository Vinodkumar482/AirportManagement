using AirportManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using System.Web.UI.WebControls;

namespace AirportManagement.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginCls l)
        {
            if(ModelState.IsValid)
            {
                LoginFromApi loginFromApi = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44338/api/");
                    var responseTask = client.GetAsync("Login/GetUser?email="+l.email);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readdata = result.Content.ReadAsAsync<LoginFromApi>();
                        readdata.Wait();
                        loginFromApi = readdata.Result;

                        if (loginFromApi != null)
                        {
                            bool passwordsMatch = l.password == loginFromApi.password;
                            if (passwordsMatch)
                            {
                                Session["email"] = loginFromApi.Email;
                                Session["type"] = loginFromApi.type;
                                if (loginFromApi.type == "Admin")
                                {
                                    return RedirectToAction("Home", "Admin");
                                }
                                else
                                {
                                    return RedirectToAction("Home", "Manager");
                                }
                            }
                            else
                            {
                                ViewBag.msg = "Invalid credentials";
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag.msg = "Invalid credentials";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Try again Later";
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}