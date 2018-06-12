using CMS.CMSContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public class CommentRepository:ICommentRepository
    {
        private readonly Context _repository;
        public CommentRepository(Context repository)
        {
            _repository = repository;
        }

        public async Task<Comment> GetAsync(int id)
        {
            return await _repository.Comments.FindAsync(id);
        }

        public void Remove(string id)
        {
            var comment = _repository.Comments.Find(id);
            _repository.Comments.Remove(comment);
        }

        public void Remove(Comment comment)
        {
            _repository.Comments.Remove(comment);
        }
    }
}