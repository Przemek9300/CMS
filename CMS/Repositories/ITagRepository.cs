using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    interface ITagRepository:IDisposable
    {

        Tag GetTagByID(Guid id);
        List<Tag> GetTagByName(String name);
        void AddTag(Tag tag);
        void DeleteTagById(Guid id);
        void DeleteTag(Tag tag);
        void ModifyTag(Tag tag);
        List<Tag> GetTags();


    }
}
