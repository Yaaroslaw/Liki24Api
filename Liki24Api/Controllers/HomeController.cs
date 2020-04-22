using System;
using System.Collections.Generic;
using System;
using System.Web.Http;
using System.Web.Mvc;


namespace Liki24Api.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateWindow()
        {
            return View();
        }
        public ActionResult GetWindows()
        {
            return View();
        }
    }
}
