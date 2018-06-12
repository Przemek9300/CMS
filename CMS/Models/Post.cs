using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishAt { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        public bool AllowComments { get; set; }
        public int Views { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}