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

            ViewBag.name = tag;
            var posts = _Repostiory.PostRepository.GetPostsByTag(tag);


            var popularTags = _Repostiory.TagRepository.GetTagsByPopular().ChunkBy(3);
            ViewBag.tag1 = popularTags[0];
            ViewBag.tag2 = popularTags[1];
            if (!String.IsNullOrEmpty(tag))
                ViewBag.tag = tag;
            else
                ViewBag.tag = "Nie znaleziono!";
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View("~/Views/Post/Index.cshtml", posts.ToPagedList(pageNumber, pageSize));




        }




    }


}
    
