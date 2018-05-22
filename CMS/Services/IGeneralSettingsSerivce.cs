using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public interface IGeneralSettingsSerivce
    {
        void SetLayout(Layout layout);
        string LoadLayout();
        string GetApplicationName();
        GeneralSettings GetSetting();
        void AddSetting(GeneralSettings c);
        SubPage GetPage(int page);

    }
}
