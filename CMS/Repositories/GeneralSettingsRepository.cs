using CMS.CMSContext;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public class GeneralSettingsRepository : IGeneralSettingsRepository
    {
        private readonly Context _repository;
        public GeneralSettingsRepository(Context repository)
        {
            _repository = repository;
        }
        public void AddConfig(GeneralSettings config)
        {
            var c = _repository.GeneralSettings.FirstOrDefault();
            if (c == null)
            {
                _repository.GeneralSettings.Add(config);
            }
            else
            {
                _repository.Entry(c).CurrentValues.SetValues(config);
            }
            _repository.SaveChanges();
        }

        public GeneralSettings GetConfig()
        {
            return _repository.GeneralSettings.FirstOrDefault();
        }

        public SubPage GetPage(int page)
        {
            switch (page)
            {
                default:
                    GeneralSettings a = _repository.GeneralSettings.FirstOrDefault();
                    if (a == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return a.Page1;
                case 1:
                    GeneralSettings s = _repository.GeneralSettings.FirstOrDefault();
                    if(s==null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return s.Page1;
                case 2:
                    GeneralSettings c = _repository.GeneralSettings.FirstOrDefault();
                    if (c == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return c.Page1;
                case 3:
                    GeneralSettings q = _repository.GeneralSettings.FirstOrDefault();
                    if (q == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return q.Page1;
                case 4:
                    GeneralSettings w = _repository.GeneralSettings.FirstOrDefault();
                    if (w == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return w.Page1;
            }
        }

        public async Task SaveAsync()
        {

                await _repository.SaveChangesAsync();
            
        }
    }
}