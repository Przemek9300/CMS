using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.Services
{
    public class RoleSerivce : IRoleSerivce
    {
        public List<string> GetRoles(List<string> id)
        {
            var list = new List<string>();
            foreach (var roleId in id)
            {
                switch (roleId)
                {
                    default:
                        break;
                    case "1":
                        list.Add("Admin");
                        break;
                    case "2":
                        list.Add("User");
                        break;
                    case "3":
                        list.Add("Moderator");
                        break;
                }
                
            }
            return list;
        }
    }
}