using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public interface IGeneralSettingsRepository
    {
        GeneralSettings GetConfig();
        void AddConfig(GeneralSettings config);


        Task SaveAsync();
    }
}
