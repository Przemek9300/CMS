﻿using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using CMS.Service;
using CMS.UnitOfWork;
using CMS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            List<PostViewModel> Vposts = new List<PostViewModel>();
            using (var context = new UoW(new Context()))
            {
                var posts = context.PostRepository.GetPosts();
                foreach(var Vpost in posts)
                {
                    Vposts.Add(new PostViewModel
                    {
                        Title = Vpost.Title,
                        AllowComments = Vpost.AllowComments,
                        Author = Vpost.Author,
                        Content = Vpost.Content,
                        Description = Vpost.Description,
                        Id = Vpost.Id.ToString(),
                        ImageUrl = Vpost.ImageUrl,
                        PublishAt = Vpost.PublishAt,
                        Tags = Vpost.Tags.ToList()
                    });
                            

                }

            }
            return View(Vposts.OrderByDescending(x=>x.PublishAt));
        }

        // GET: Post/Details/
        [AllowAnonymous]
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
            var post = new PostViewModel();
            using (var context = new UoW(new Context()))
            {

                var list = context.TagRepository.GetTags().Select(c => new {
                    Id = c.Id,
                    Value = c.Name
                }).ToList();
                post.Options = new MultiSelectList(list, "Id", "Value");
            }
           
            return View(post);
        }

        // POST: Post/Create
        [HttpPost]
        public async Task<ActionResult> Create(HttpPostedFileBase file, PostViewModel post)
        {
            try
            {
                // TODO: Add insert logic here
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    int idx = fileName.LastIndexOf('.');
                    var extensions = fileName.Substring(idx + 1);
                    if (!ImageService.IsImage(extensions))
                        return RedirectToAction("Create");

                    var path = Path.Combine(Server.MapPath("~/Content/Images/Posts"), fileName);
                    var serverPath = ImageService.ImagePostPathServer(fileName);

                    using (var context = new UoW(new Context()))
                    {
                        var listTags = new List<Tag>();
                        foreach (var tag in post.SelectedOptions)
                            listTags.Add(context.TagRepository.GetTagByID(Guid.Parse(tag)));
                        if (post != null)
                        {
                            post.Id = Guid.NewGuid().ToString();
                            post.PublishAt = DateTime.Now;
                            context.PostRepository.AddPost(new Post
                            {
                                Title = post.Title,
                                AllowComments = post.AllowComments,
                                Author = post.Author,
                                Content = post.Content,
                                Description = post.Description,
                                Id = Guid.Parse(post.Id),
                                ImageUrl = serverPath,
                                PublishAt = post.PublishAt,
                                Tags = listTags
                            });

                            await context.SaveAsync();
                            file.SaveAs(path);
                        }
                        
                    }
                }

                return RedirectToAction("Index");
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
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
        public async Task<ActionResult> Edit(HttpPostedFileBase file , Guid id, Post post)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    int idx = fileName.LastIndexOf('.');
                    var extensions = fileName.Substring(idx + 1);
                    if (!ImageService.IsImage(extensions))
                        return RedirectToAction("Create");

                    var path = Path.Combine(Server.MapPath("~/Content/Images/Posts"), fileName);
                    var serverPath = ImageService.ImagePostPathServer(fileName);
                    using (var context = new UoW(new Context()))
                    {
                        post.ImageUrl = serverPath;
                        context.PostRepository.ModifyPost(post);
                        await context.SaveAsync();
                    }
                    file.SaveAs(path);
                }



                    return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
                    };
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
