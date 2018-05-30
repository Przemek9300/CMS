using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services
{
    public interface IRoleSerivce
    {
        List<string> GetRoles(List<string> id);
    }
}
