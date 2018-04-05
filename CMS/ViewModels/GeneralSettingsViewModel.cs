using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.ViewModels
{
    public class GeneralSettingsViewModel
    {
        public Guid Id { get; set; }
        public string ApplicationName { get; set; }
        public string LogoUrl { get; set; }
        public bool CommentsSections { get; set; }
        public int ArticlesInOneView { get; set; }
        public virtual Layout Layout { get; set; }
    }
}