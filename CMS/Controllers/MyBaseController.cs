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
    public abstract class MyBaseController : Controller
    {
        public MainLayoutViewModel MainLayoutViewModel { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var service = new GeneralSettingsService(new GeneralSettingsRepository(new CMSContext.Context()));
            MainLayoutViewModel = new MainLayoutViewModel
            {
                PageTitle = service.GetApplicationName(),
                Label1 = service.GetPage(1).Label,
                Label2 = service.GetPage(2).Label,
                Label3 = service.GetPage(3).Label,
                Label4 = service.GetPage(4).Label
            };



            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
        }

    }

}