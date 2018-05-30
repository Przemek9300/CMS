using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
   public interface ITagRepository:IDisposable
    {

        Tag GetTagByID(Guid id);
        List<Tag> GetTagByName(String name);
        List<Tag> GetTagsByPost(Guid id);
        
        void AddTag(Tag tag);
        void DeleteTagById(Guid id);
        void DeleteTag(Tag tag);
        void ModifyTag(Tag tag);
        Task  SaveAsync();

        List<Tag> GetTags();


    }
}
