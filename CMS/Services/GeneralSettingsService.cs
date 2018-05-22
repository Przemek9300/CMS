﻿using CMS.CMSContext;
using CMS.Models;
using CMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Services
{
    public  class GeneralSettingsService:IGeneralSettingsSerivce
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
        public  string LoadLayout()
        {
            using (Context context = new Context())
            {
                var settings = context.GeneralSettings.FirstOrDefault();
                if (settings.Layout != null)
                    return settings.Layout.Location;
            }
            return "~/Content/site.css";


        }
        public  string GetApplicationName()
        {
            using (Context context = new Context())
            {
                var settings = context.GeneralSettings.FirstOrDefault();
                if (settings.ApplicationName != null)
                    return settings.ApplicationName;
            }
            return "Blog";


        }

        public GeneralSettings GetSetting()
        {
            return _settingContext.GetConfig();
        }

        public void AddSetting(GeneralSettings c)
        {
            _settingContext.AddConfig(c);
        }

        public SubPage GetPage(int page)
        {
            return _settingContext.GetPage(page);
        }
    }
 }
