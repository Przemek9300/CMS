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
            return _repository.GeneralSettings.First();
        }

        public async Task SaveAsync()
        {

                await _repository.SaveChangesAsync();
            
        }
    }
}