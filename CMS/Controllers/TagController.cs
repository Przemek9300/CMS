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

        public ActionResult Index(string query, int? page)
        {
            ViewBag.newestPost = _Repostiory.PostRepository.GetPosts().Take(6).OrderByDescending(x => x.PublishAt).ToList();
            ViewBag.name = "#"+query;
            var posts = _Repostiory.PostRepository.GetPostsByTag(query);


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
            if (!String.IsNullOrEmpty(query))
                ViewBag.tag = query;
            else
                ViewBag.tag = "Nie znaleziono!";
            int pageSize = _Repostiory.GeneralSettingsRepository.GetArticlesinPage();
            int pageNumber =  pageNumber = (page ?? 1);
            return View("~/Views/Post/Index.cshtml", posts.ToPagedList(pageNumber, pageSize));




        }




    }


}
    
