﻿using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.ViewModels
{
    public class PostViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool AllowComments { get; set; }
        public MultiSelectList Options { set; get; }
        public string[] SelectedOptions { set; get; }
        public virtual List<Tag> Tags { get; set; }
    }
}