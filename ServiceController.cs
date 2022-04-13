using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using ServiceCo.Models;
using ServiceCo.Manager;
using ServiceCo.Filters;

namespace ServiceCo.Controllers
{
    [AuthorizedUser]
    [ExceptionFilter]
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(ServiceModel Service)
        {

            if (ModelState.IsValid)
            {
                ServiceManager obj = new ServiceManager();
                bool check = obj.AddService(Service);
                if (check)
                {
                    TempData["Message"] = "Data inserted. Your id is "+check;
                    return RedirectToAction("ViewService");
                }
                else
                {
                    TempData["Message"] = "Data not inserted";
                    return View();
                }

            }
            else
            {
                TempData["Message"] = "Data not correct";
                return View();
            }

        }
        public ActionResult SearchService(ServiceModel Servicee)
        {
            ServiceModel Service = (ServiceModel)TempData["Servicee"];

            return View(Service);
        }
        public ActionResult ViewService()
        {
            ServiceManager Obj = new ServiceManager();
            List<ServiceModel> ServiceMembers = Obj.GetAllService();
            return View(ServiceMembers);
        }

        [HttpGet]
        public ActionResult UpdateService(int FID)
        {
            ServiceManager obj = new ServiceManager();
            ServiceModel Service = obj.GetService(FID);
            return View(Service);
        }
        [HttpPost]
        public ActionResult UpdateService(ServiceModel Service)
        {
            ServiceManager obj = new ServiceManager();
            bool check = obj.UpdateService(Service);
            if (check)
            {
                return RedirectToAction("ViewService");

            }
            else
            {
                TempData["Message"] = "Some error";
                return View(Service);
            }

        }
       
        public ActionResult DeleteService(int FID)
        {
            ServiceManager Obj = new ServiceManager();
            bool check = Obj.DeleteService(FID);
            if (check)
            {
                TempData["Message"] = "Data Deleted";
            }
            else
            {
                TempData["Message"] = "Data not deleted";
            }
            return RedirectToAction("ViewService");
        }

        
    }
}