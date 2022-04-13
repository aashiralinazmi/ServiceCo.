using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceCo.Models;
using ServiceCo.Manager;
using ServiceCo.Filters;

namespace ServiceCo.Controllers
{
    [ExceptionFilter]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel LoginData)
        {
            if (ModelState.IsValid)
            {
                LoginManager obj = new LoginManager();
                ServiceModel ServiceData = obj.CheckLogin(LoginData);
                if (ServiceData != null)
                {
                    Session["IsLogin"] = true;
                    Session["FID"] = ServiceData.FID;
                    Session["LoginID"] = ServiceData.LoginInfo.LoginID;
                    Session["PersonName"] = ServiceData.FirstName + " " + ServiceData.LastName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Username or Password incorrect";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Please Enter username and password first";
                return View();
            }
        }
    }
}