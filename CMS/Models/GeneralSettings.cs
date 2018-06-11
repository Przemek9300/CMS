using System;
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
        [Display(Name = "Nazwa Aplikacji" )]
        public string ApplicationName { get; set; }
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }
        [Display(Name = "Sekcja Komentarzy")]
        public bool CommentsSections { get; set; }
        [Display(Name = "Ilość artykułów na strone")]
        public int ArticlesInOneView { get; set; }
        public virtual Layout Layout { get; set; }
        public virtual SubPage Page1 { get; set; }
        public virtual SubPage Page2 { get; set; }
        public virtual SubPage Page3 { get; set; }

    }
}