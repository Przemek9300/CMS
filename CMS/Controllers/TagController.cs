using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using CMS.UnitOfWork;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class TagController : MyBaseController
    {
        private readonly IUoW _Repostiory;

        // GET: Tag
        public TagController(IUoW _Repostiory)
        {
            this._Repostiory = _Repostiory;
        }
     
        public ActionResult Index(string tag, int? page)
        {

            
                var posts = _Repostiory.PostRepository.GetPostsByTag(tag);



            if (!String.IsNullOrEmpty(tag))
                ViewBag.tag = tag;
            else
                ViewBag.tag = "Nie znaleziono!";
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));




        }


        // GET: Tag/Details/5
        public ActionResult Details(Guid id)
        {

                var tag = _Repostiory.TagRepository.GetTagByID(id);
                return View(tag);
            
            
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

                    if (!tag.Name.StartsWith("#"))
                        tag.Name = "#" + tag.Name;
                    _Repostiory.TagRepository.AddTag(tag);
                    await _Repostiory.SaveAsync();
                    // TODO: Add insert logic here
                
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
    
