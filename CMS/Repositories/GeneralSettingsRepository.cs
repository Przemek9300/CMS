using CMS.CMSContext;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            //TODO VALIDATION
            _repository.GeneralSettings.Add(config);
        }

        public void DeleteConfig(GeneralSettings config)
        {
            //TODO CHECK IS EXIST
            _repository.GeneralSettings.Remove(config);
        }

        public void DeleteConfigById(Guid id)
        {
            

            
        }

        public List<GeneralSettings> GetConfigByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<GeneralSettings> GetConfigs()
        {
            return _repository.GeneralSettings.ToList();
        }


        public GeneralSettings GetConfigtByID(Guid id)
        {
            return _repository.GeneralSettings.Find(id);
        }

        public void ModifyConfig(GeneralSettings config)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}