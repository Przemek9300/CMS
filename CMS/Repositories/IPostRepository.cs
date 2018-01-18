using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    interface IPostRepository:IDisposable
    {
        Post GetPostByID(Guid id);
        List<Post> GetPosts();
        List<Post> GetPostByTitle(String title);
        List<Post> GetPostsByQueryTag(string tag);
        List<Post> GetPostsByTag(String tag);
        void AddPost(Post post);
        void DeletePostById(Guid id);
        void DeletePost(Post post);
        void ModifyPost(Post post);
        void SaveChanges();


    }
}
