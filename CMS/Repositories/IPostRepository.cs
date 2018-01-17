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
        List<Post> GetPostByTitle(String title);
        void AddPost(Post post);
        void DeletePostById(Guid id);
        void DeletePost(Post post);
        void ModifyPost(Post post);


    }
}
