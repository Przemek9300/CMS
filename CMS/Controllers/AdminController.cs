using CMS.CMSContext;
using CMS.Models;
using CMS.Services;
using CMS.UnitOfWork;
using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGeneralSettingsSerivce setting;

        public AdminController(IGeneralSettingsSerivce setting)
        {
            this.setting = setting;
        }
        // GET: Admin
        public ActionResult Index()
        {

            var s = setting.GetSetting();
                return View(s);
           

        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public async Task<ActionResult> Create(GeneralSettingsViewModel collection)
        {
            if (!ModelState.IsValid)
            {
                return View(collection);
            }

            try
            {



                setting.AddSetting(
                    new GeneralSettings
                    {
                        ApplicationName = collection.ApplicationName,
                        ArticlesInOneView = collection.ArticlesInOneView,
                        CommentsSections = collection.CommentsSections,
                        Id = collection.Id,
                        Layout = collection.Layout,
                        LogoUrl = collection.LogoUrl
                    });




                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Chart()
        {
            using (var context = new Context())
            {
                
                return View();
            }

        }
        public ActionResult Themes()
        {
            using (var context = new Context())
            {

                return View();
            }

        }
        public ActionResult Roles()
        {
            using (var context = new Context())
            {

                return View();
            }

        }
        public ActionResult Settings()
        {
            using (var context = new Context())
            {

                return View();
            }

        }
        public ActionResult SubPage(int id)
        {

                ViewBag.id = id;
                return View();
            

        }
        [HttpPost]
        public ActionResult SubPage(SubPage page, int? id)
        {
            if (ModelState.IsValid)
            {
 
                    var config = setting.GetSetting();
                    switch (id)
                    {
                        default:
                            config.Page1 = page;
                            break;
                        case 1:
                            config.Page1 = page;
                            break;


                        case 2:
                            config.Page2 = page;
                            break;

                        case 3:
                            config.Page3 = page;
                            break;

                        case 4:
                            config.Page4 = page;
                            break;
                    }
                    setting.AddSetting(config);
                    if (id >= 4)
                        return RedirectToAction("Themes", "Admin");
                    return RedirectToAction("SubPage", "Admin", new { id = id + 1 });
                }
            
            return View(page);

        }



    }
}
