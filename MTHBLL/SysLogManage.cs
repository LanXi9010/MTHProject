using MTHDAL;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHBLL
{
    public  class SysLogManage
    {
        public SysLogService sysLogService=new SysLogService();
        public bool AddSysLog(SysLog sysLog)
        {
            return sysLogService.AddSysLog(sysLog) == 1;
        }

        public DataTable QuerySysLogByCondition(string start, string end, string alarmType)
        {
            return sysLogService.QuerySqlLogByCondition(start, end, alarmType);
        }
    }
}
