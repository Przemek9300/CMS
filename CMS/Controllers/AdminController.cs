using CMS.CMSContext;
using CMS.Models;
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
        // GET: Admin
        public ActionResult Index()
        {
            using (var context = new Context())
            {
                var s = context.GeneralSettings.ToList();
                return View(s);
            }

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
                
                    using (var context = new UoW(new Context())) {

                        context.GeneralSettings.AddConfig(
                            new GeneralSettings
                            {
                                ApplicationName = collection.ApplicationName,
                                ArticlesInOneView = collection.ArticlesInOneView,
                                CommentsSections = collection.CommentsSections,
                                Id = collection.Id,
                                Layout = collection.Layout,
                                LogoUrl = collection.LogoUrl
                            }

                            
                            );
                    await context.SaveAsync();


                }

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
    }
}
