using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceCo.Filters;

namespace ServiceCo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCustomer()
        {
            throw new NullReferenceException();
        }
        public ActionResult SearchCustomer()
        {
            throw new Exception("There was an error");
        }
        public ActionResult ViewCustomer()
        {
            return View();
        }
    }
}