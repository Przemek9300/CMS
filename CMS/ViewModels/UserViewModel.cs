using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.ViewModels
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}