using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace CMS.Service
{
    public static class ImageService
    {
        private static List<String> imagesExtensions = new List<string> { "jpg", "png" };
        public static bool IsImage(String extension)
        {
            if (imagesExtensions.Contains(extension))
                return true;
            return false;
        }
        public static String ImagePostPathServer(String file)
        {
            return "\\Content\\Images\\Posts\\" + file;
        }
    }
}