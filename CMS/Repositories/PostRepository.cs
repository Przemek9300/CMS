using CMS.CMSContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;
using System.Threading.Tasks;

namespace CMS.Repositories
{


    public class PostRepository:IPostRepository
    {
        private readonly Context _repository;
        public PostRepository(Context repository)
        {
            _repository = repository;
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
            post.ModifyAt = DateTime.Now;
            var p = GetPostByID(post.Id);
            post.PublishAt = p.PublishAt;
            _repository.Entry(p).CurrentValues.SetValues(post);
            
        }

        public List<Post> GetPostsByQueryTag(string tag)
        {
            return _repository.Posts.Where<Post>(X => X.Tags.Any(y => y.Name.Contains(tag))).ToList();
        }

        public List<Post> GetPostsByTag(string tag)
        {
            return _repository.Posts.Where<Post>(X => X.Tags.Any(y => y.Name==tag)).ToList();
        }

        public List<Post> GetPosts()
        {
            return _repository.Posts.Select(x => x).ToList();
        }


        public List<Post> GetPostByQuery(string query)
        {
            return _repository.Posts.Where(x => x.Title.ToLower().Contains(query.ToLower())).ToList();
        }
        public async Task SaveAsync()
        {

            await _repository.SaveChangesAsync();

        }


    }
}