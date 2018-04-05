using CMS.CMSContext;
using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CMS.UnitOfWork
{
    public class UoW:IDisposable
    {

        private readonly Context _context;
        public UoW(Context context)
        {
            _context = context;

        }
        private PostRepository _postRepository;

        public PostRepository PostRepository
        {
            get
            {
                if (_postRepository == null)
                {
                    _postRepository = new PostRepository(_context);
                }

                return _postRepository;
            }
        }


        private TagRepository _tagRepository;

        public TagRepository TagRepository
        {
            get
            {
                if (_tagRepository == null)
                {
                    _tagRepository = new TagRepository(_context);
                }

                return _tagRepository;
            }
        }
        private GeneralSettingsRepository _generalSettings;
        public GeneralSettingsRepository GeneralSettings
        {
            get
            {
                if (_generalSettings == null)
                {
                    _generalSettings = new GeneralSettingsRepository(_context);
                }

                return _generalSettings;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}