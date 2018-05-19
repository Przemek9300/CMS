using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models
{
    public class SubPage
    {
        public int Id { get; set; }
        public string Label { get; set; }
        [AllowHtml]
        public string CodeHtml { get; set; }
    }
}