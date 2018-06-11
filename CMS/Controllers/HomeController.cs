using CMS.Models;
using CMS.Repositories;
using CMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class HomeController : MyBaseController
    {
        private readonly IGeneralSettingsSerivce serivce;

        public HomeController(IGeneralSettingsSerivce serivce)
        {
            this.serivce = serivce;
        }
        public ActionResult Index()
        {
            var content = serivce.GetPage(1);
            return View(content);
        }

        public ActionResult About()
        {
            var content = serivce.GetPage(2);
            

            return View(content);
        }

        public ActionResult Contact()
        {
            var content = serivce.GetPage(3);
            return View(content);
        }
    }
}