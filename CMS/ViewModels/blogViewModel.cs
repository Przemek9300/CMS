using CMS.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.ViewModels
{
    public class BlogViewModel
    {
        public IPagedList<PostViewModel> Posts { get; set; }
        public List<List<Tag>> RecomendedTags { get; set; }
    }
}