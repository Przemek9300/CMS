using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using CMS.Service;
using CMS.UnitOfWork;
using CMS.ViewModels;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;

namespace CMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostController : MyBaseController
    {
        private readonly IUoW _Repostiory;

        public PostController(IUoW _repostiory)
        {
            _Repostiory = _repostiory;
        }

        // GET: Post
        [AllowAnonymous]
        public async Task<ActionResult> Index(int? page, string query)
        {
            ViewBag.newestPost = _Repostiory.PostRepository.GetPosts().Take(6).OrderByDescending(x => x.PublishAt).ToList();

            ViewBag.name = "Blog";
            List<Post> posts = null;
            var popularTags = _Repostiory.TagRepository.GetTagsByPopular().ChunkBy(3);
            if (popularTags != null && popularTags.Count!=0)
            {
                ViewBag.tag1 = popularTags[0];
                if(popularTags.Count==2)
                 ViewBag.tag2 = popularTags[1];
                else
                    ViewBag.tag2 = new List<Tag>();

            }
            else
            {
                ViewBag.tag1 = new List<Tag>();
                ViewBag.tag2 = new List<Tag>();
            }

            if (String.IsNullOrEmpty(query))
                posts = _Repostiory.PostRepository.GetPosts().OrderByDescending(x => x.PublishAt).ToList();
            else
                posts = _Repostiory.PostRepository.GetPostByQuery(query).OrderByDescending(x => x.PublishAt).ToList();






            int pageSize = _Repostiory.GeneralSettingsRepository.GetArticlesinPage();
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        // GET: Post/Details/
        [AllowAnonymous]
        public async Task<ActionResult> Details(Guid id)
        {
            ViewBag.newestPost = _Repostiory.PostRepository.GetPosts().Take(6).OrderByDescending(x => x.PublishAt).ToList();
            var popularTags = _Repostiory.TagRepository.GetTagsByPopular().ChunkBy(3);
            if (popularTags != null && popularTags.Count != 0)
            {
                ViewBag.tag1 = popularTags[0];
                if (popularTags.Count == 2)
                    ViewBag.tag2 = popularTags[1];
                else
                    ViewBag.tag2 = new List<Tag>();

            }
            else
            {
                ViewBag.tag1 = new List<Tag>();
                ViewBag.tag2 = new List<Tag>();
            }
            ViewBag.newestPost = _Repostiory.PostRepository.GetPosts().Take(6).OrderByDescending(x => x.PublishAt).ToList();
            var post = _Repostiory.PostRepository.GetPostByID(id);
            if (post != null)
            {
                post.Views += 1;
                _Repostiory.PostRepository.ModifyPost(post);
                await _Repostiory.PostRepository.SaveAsync();
                return View(post);
            }
            return RedirectToAction("Index");

        }

        // GET: Post/Create
        public ActionResult Create()
        {
            var post = new PostViewModel();




            return View();
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


                    var listTags = new List<Tag>();
                    var tags = post.Options.Split(',');

                    foreach (var tag in tags)
                        listTags.Add(_Repostiory.TagRepository.GetTagOrAdd(tag));

                    if (post != null)
                    {
                        post.Id = Guid.NewGuid().ToString();
                        post.PublishAt = DateTime.Now;
                        _Repostiory.PostRepository.AddPost(new Post
                        {
                            Title = post.Title,
                            AllowComments = post.AllowComments,
                            Author = User.Identity.Name,
                            Content = post.Content,
                            Description = post.Description,
                            Id = Guid.Parse(post.Id),
                            ImageUrl = serverPath,
                            PublishAt = post.PublishAt,
                            Tags = listTags,


                        });

                        await _Repostiory.SaveAsync();
                        file.SaveAs(path);
                    }


                }

                return RedirectToAction("Index");
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(Guid id)
        {


            var post = _Repostiory.PostRepository.GetPostByID(id);
            return View(post);


        }

        // POST: Post/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(HttpPostedFileBase file, Guid id, Post post)
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

                    post.ImageUrl = serverPath;
                    _Repostiory.PostRepository.ModifyPost(post);
                    await _Repostiory.SaveAsync();

                    file.SaveAs(path);
                }



                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Post/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var post = _Repostiory.PostRepository.GetPostByID(id);

            return View(post);
        }

        [WebMethod]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Autocomplete(string query)
        {
            if (query.StartsWith("#"))
            {
                var tag = query.Split('#')[1];
                var tags = _Repostiory.TagRepository.GetTagsByQuery(tag).Select(r => new { label = r.Name, value = Url.Action("Index", "Tag", new { query = r.Name }) }).Take(5).ToList();
                return Json(tags, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var posts = _Repostiory.PostRepository.GetPostByQuery(query).Select(r => new { label = r.Title, value = Url.Action("Details", "Post", new { id = r.Id }) }).Take(5).ToList();
                return Json(posts, JsonRequestBehavior.AllowGet);

            }
        }







        // POST: Post/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Guid id, FormCollection collection)
        {
            try
            {

                var post = _Repostiory.PostRepository.GetPostByID(id);
                if (post != null)
                {
                    _Repostiory.PostRepository.DeletePost(post);
                    await _Repostiory.SaveAsync();
                };

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> AddCommentAsync(string content, string postID)
        {
            string author = User.Identity.Name;
            if (String.IsNullOrEmpty(author))
                author = "Anonim";
            Comment comment = new Comment()
            {
                Author = author,
                Content = content,
                PublishAt = DateTime.Now,
                Edited = true


            };
            var post = _Repostiory.PostRepository.GetPostByID(Guid.Parse(postID));
            post.Comments.Add(comment);
            await _Repostiory.SaveAsync();


            return RedirectToAction("Details", new { id = postID });

        }
        public async Task<ActionResult> RemoveCommentAsync(string commentId, string postId)
        {
            var comment = await _Repostiory.CommentRepository.GetAsync(Int32.Parse(commentId));
            _Repostiory.CommentRepository.Remove(comment);
            await _Repostiory.SaveAsync();


            return RedirectToAction("Details", new { id = postId });
        }
        public async Task<ActionResult> EditCommentAsync(string commentId, string postId)
        {
            var comment = await _Repostiory.CommentRepository.GetAsync(Int32.Parse(commentId));
            var objectJson = JsonConvert.SerializeObject(comment);
            return Json(objectJson);
        }

    }

}
