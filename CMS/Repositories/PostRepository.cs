using CMS.CMSContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;

namespace CMS.Repositories
{

    public class PostRepository:IPostRepository
    {
        private Context _repository;
        public PostRepository()
        {
            _repository = new Context();
        }

        public void AddPost(Post post)
        {
            _repository.Posts.Add(post);
        }

        public Post GetPostByID(Guid id)
        {
            return _repository.Posts.First(x => x.Id.Equals(id));
        }

        public List<Post> GetPostByTitle(string title)
        {
            return _repository.Posts.Where(x => x.Title.Equals(title)).ToList<Post>();
        }
        public void Dispose()
        {
            _repository.Dispose();
        }

        public void DeletePostById(Guid id)
        {
            var post = GetPostByID(id);
            if (post != null)
                _repository.Posts.Remove(post);
        }

        public void DeletePost(Post post)
        {
            if (post != null)
                _repository.Posts.Remove(post);
        }

        public void ModifyPost(Post post)
        {
            ;
        }
    }
}