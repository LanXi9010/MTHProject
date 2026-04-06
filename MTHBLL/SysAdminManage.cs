using MTHDAL;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHBLL
{
    public class SysAdminManage
    {
        public SysAdminService sysAdminService = new SysAdminService();
        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            return sysAdminService.AdminLogin(sysAdmin);
        }
        public bool AddSysAdmin(SysAdmin sysAdmin)
        {
            return sysAdminService.AddSysAdmin(sysAdmin) == 1;
        }

        public bool DeleteSysAdmin(int loginId)
        {
            return sysAdminService.DeleteSysAdmin(loginId) == 1;
        }

        public bool ModifySysAdmin(SysAdmin sysAdmin)
        {
            return sysAdminService.ModifySysAdmin(sysAdmin) == 1;
        }

        public List<SysAdmin> QuerySysAdmins()
        {
            return sysAdminService.QuerySysAdmins();
        }
    }
}
