using CMS.Repositories;
using CMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeneralSettingsSerivce serivce;

        public HomeController(IGeneralSettingsSerivce serivce)
        {
            this.serivce = serivce;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = serivce.GetApplicationName();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}