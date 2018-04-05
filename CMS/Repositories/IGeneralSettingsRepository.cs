using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    interface IGeneralSettingsRepository
    {
        GeneralSettings GetConfigtByID(Guid id);
        List<GeneralSettings> GetConfigs();
        List<GeneralSettings> GetConfigByTitle(String title);
        void AddConfig(GeneralSettings config);
        void DeleteConfigById(Guid id);
        void DeleteConfig(GeneralSettings config);
        void ModifyConfig(GeneralSettings config);
    }
}
