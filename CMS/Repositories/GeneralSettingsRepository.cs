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

        public int GetArticlesinPage()
        {
            var amount = _repository.GeneralSettings.First().ArticlesInOneView;
            if (amount < 1)
                return 1;
            return amount;
        }

        public GeneralSettings GetConfig()
        {
            return _repository.GeneralSettings.FirstOrDefault();
        }

        public SubPage GetPage(int page)
        {
            GeneralSettings config = null;
            switch (page)
            {
                default:

                        return new SubPage() { CodeHtml = "", Label = "defualt" };

                case 1:
                     config = _repository.GeneralSettings.FirstOrDefault();
                    if(config == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return config.Page1;
                case 2:
                    config = _repository.GeneralSettings.FirstOrDefault();
                    if (config == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return config.Page2;
                case 3:
                     config = _repository.GeneralSettings.FirstOrDefault();
                    if (config == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return config.Page3;
                case 4:
                     config = _repository.GeneralSettings.FirstOrDefault();
                    if (config == null)
                        return new SubPage() { CodeHtml = "", Label = "defualt" };
                    return config.Page4;
            }
        }

        public async Task SaveAsync()
        {

                await _repository.SaveChangesAsync();
            
        }
    }
}