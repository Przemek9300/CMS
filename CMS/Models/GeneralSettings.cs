﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class GeneralSettings
    {
        [Key]
        public Guid Id { get; set; }
        public string ApplicationName { get; set; }
        public string LogoUrl { get; set; }
        public bool CommentsSections { get; set; }
        public int ArticlesInOneView { get; set; }
        public virtual Layout Layout { get; set; }
        public virtual SubPage Page1 { get; set; }
        public virtual SubPage Page2 { get; set; }
        public virtual SubPage Page3 { get; set; }
        public virtual SubPage Page4 { get; set; }

    }
}