using CMS.CMSContext;
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
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        // GET: Post
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Post> posts;
            using (var context = new UoW(new Context()))
            {
                posts = context.PostRepository.GetPosts();
            }
            return View(posts);
        }

        // GET: Post/Details/5
        public ActionResult Details(Guid id)
        {
            using (var context = new UoW(new Context()))
            {
                var post = context.PostRepository.GetPostByID(id);
                return View(post);
            }
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public async Task<ActionResult> Create(Post post)
        {
            try
            {
                // TODO: Add insert logic here
                using (var context = new UoW(new Context()))
                {

                    if (post != null)
                    {
                        post.Id = Guid.NewGuid();
                        post.PublishAt = DateTime.Now;
                        context.PostRepository.AddPost(post);
                       await context.SaveAsync();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(Guid id)
        {
            using (var context = new UoW(new Context()))
            {
                var post = context.PostRepository.GetPostByID(id);
                     return View(post);
            }
           
        }

        // POST: Post/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, Post post)
        {
            try
            {
                using (var context = new UoW(new Context()))
                {
                    context.PostRepository.ModifyPost(post);
                    await context.SaveAsync();
                }



                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, FormCollection collection)
        {
            try
            {
                using (var context = new UoW(new Context()))
                {
                    var post = context.PostRepository.GetPostByID(id);
                    if (post != null)
                    {
                        context.PostRepository.DeletePost(post);
                        await context.SaveAsync();
                    }
                }
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
