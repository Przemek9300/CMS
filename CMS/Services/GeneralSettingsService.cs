using CMS.CMSContext;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Services
{
    public static class GeneralSettingsService
    {
        public static void SetLayout(Layout layout)
        {
            using (Context context = new Context())
            {
                var settings = context.GeneralSettings.First();
                settings.Layout = layout;
                context.SaveChanges();
            }
        }
        public static string LoadLayout()
        {
            using (Context context = new Context())
            {
                var settings = context.GeneralSettings.FirstOrDefault();
                if (settings.Layout != null)
                    return settings.Layout.Location;
            }
            return "~/Content/site.css";


        }
    }
 }
