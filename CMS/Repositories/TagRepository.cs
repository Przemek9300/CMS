using CMS.CMSContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;
using System.Threading.Tasks;

namespace CMS.Repositories
{

    public class TagRepository:ITagRepository
    {
        private readonly Context _repository;
        public TagRepository(Context repository)
        {
            _repository = repository;
        }

        public void AddTag(Tag tag)
        {
            tag.Id = Guid.NewGuid();
            _repository.Tags.Add(tag);
            _repository.SaveChanges();
        }

        public void DeleteTag(Tag tag)
        {
            _repository.Tags.Remove(tag);
        }

        public void DeleteTagById(Guid id)
        {
            var tag = _repository.Tags.Find(id);
            if (tag != null)
                _repository.Tags.Remove(tag);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Tag GetTagByID(Guid id)
        {
            var tag = _repository.Tags.Find(id);
            return tag;
        }

        public List<Tag> GetTagByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetTagsByPost(Guid id)
        {
            return _repository.Tags.Where<Tag>(x => x.Posts.Any(y => y.Id == id)).ToList();
        }

        public List<Tag> GetTags()
        {
            return _repository.Tags.Select(row => row).ToList();
        }

        public void ModifyTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {

            await _repository.SaveChangesAsync();

        }
    }

}
