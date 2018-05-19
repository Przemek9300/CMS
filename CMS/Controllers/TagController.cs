using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using CMS.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CMS.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagRepository tRepostiory;
        private readonly IPostRepository pRepostiory;

        // GET: Tag
        public TagController(ITagRepository tRepostiory, IPostRepository pRepostiory)
        {
            this.tRepostiory = tRepostiory;
            this.pRepostiory = pRepostiory;
        }
        public ActionResult Index()
        {
            List<Tag> Tags;

                Tags = tRepostiory.GetTags();
            

            return View(Tags);

        }
        public ActionResult Index1(string tag)
        {
            var trueTag = String.Concat("#", tag);

            
                var posts = pRepostiory.GetPostsByTag(trueTag);
                return View(posts);
            

               

        }


        // GET: Tag/Details/5
        public ActionResult Details(Guid id)
        {

                var tag = tRepostiory.GetTagByID(id);
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
                    tRepostiory.AddTag(tag);
                    await tRepostiory.SaveAsync();
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
    
