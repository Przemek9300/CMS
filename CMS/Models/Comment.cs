using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishAt { get; set; }
        public bool Edited { get; set; }

        public virtual Post Posts { get; set; }
    }
}