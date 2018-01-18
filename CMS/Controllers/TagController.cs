using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class TagController : Controller
    {
        // GET: Tag
        public ActionResult Index()
        {
            List<Tag> Tags;
            using (var repository = new TagRepository())
            {
                Tags = repository.GetTags();
            }

            return View(Tags);

        }

        // GET: Tag/Details/5
        public ActionResult Details(Guid id)
        {
            using (var repository = new TagRepository())
            {
                var tag = repository.GetTagByID(id);
                return View(tag);
            }
            
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        [HttpPost]
        public ActionResult Create(Tag tag)
        {

            try
            {
                using (var _repository = new TagRepository())
                {
                    if (!tag.Name.StartsWith("#"))
                        tag.Name = "#" + tag.Name;
                    _repository.AddTag(tag);
                    _repository.SaveChanges();
                    // TODO: Add insert logic here
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tag/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tag/Edit/5
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

        // GET: Tag/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
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
    
