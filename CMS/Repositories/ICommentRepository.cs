using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Repositories
{
    public interface ICommentRepository
    {
         void Remove(string id);
        void Remove(Comment comment);
        Task<Comment> GetAsync (int id);
    }
}