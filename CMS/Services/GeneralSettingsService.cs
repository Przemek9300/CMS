using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class GeneralSettingsService : IGeneralSettingsSerivce
    {

        private readonly IGeneralSettingsRepository _settingContext;

        public GeneralSettingsService(IGeneralSettingsRepository settingContext)
        {
            _settingContext = settingContext;
        }
        public void SetLayout(Layout layout)
        {
            using (Context context = new Context())
            {
                var settings = _settingContext.GetConfig();
                settings.Layout = layout;
                context.SaveChanges();
            }
        }
        public string LoadLayout()
        {
            using (Context context = new Context())
            {
                var settings = context.GeneralSettings.FirstOrDefault();
                if (settings.Layout != null)
                    return settings.Layout.Location;
            }
            return "~/Content/site.css";


        }
        public string GetApplicationName()
        {
            using (Context context = new Context())
            {
                var settings = context.GeneralSettings.FirstOrDefault();
                if (settings != null )
                    return settings.ApplicationName;
            }
            return "Blog";


        }

        public GeneralSettings GetSetting()
        {
            var settings = _settingContext.GetConfig();
            if (settings == null) {
                settings = new GeneralSettings();
                _settingContext.AddConfig(settings);
            }
            return settings;

        }

        public void AddSetting(GeneralSettings c)
        {
            _settingContext.AddConfig(c);
        }

        public SubPage GetPage(int page)

        {
            var subpage = _settingContext.GetPage(page);
            if (subpage != null && !String.IsNullOrEmpty(subpage.Label))
                return subpage;
            return new SubPage()
            {
                CodeHtml = "empty",
                Label = "Default"
            };
        }

        public async Task SaveAsync()
        {
            await _settingContext.SaveAsync();
        }

        public int AriclesInPage () 
        {
            var amount = _settingContext.GetArticlesinPage();
            if (amount < 1)
                return 1;
            return amount;
        }
    }
 }
