﻿using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using CMS.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            using (var repository = new UoW(new Context()))
            {
                Tags = repository.TagRepository.GetTags();
            }

            return View(Tags);

        }

        // GET: Tag/Details/5
        public ActionResult Details(Guid id)
        {
            using (var repository = new UoW(new Context()))
            {
                var tag = repository.TagRepository.GetTagByID(id);
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
        public async Task<ActionResult> Create(Tag tag)
        {

            try
            {
                using (var repository = new UoW(new Context()))
                {
                    if (!tag.Name.StartsWith("#"))
                        tag.Name = "#" + tag.Name;
                    repository.TagRepository.AddTag(tag);
                    await repository.SaveAsync();
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
    