using MTHModels;
using MTHProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTHDAL
{
    public class SysLogService
    {
        #region 执行Sql语句返回受影响行
        public int AddSysLog(SysLog sysLog)
        {
            string sql = "Insert into SysLog(InsertTime,Note,Operator,VarName,AlarmType)";
            sql += "values(@InsertTime,@Note,@Operator,@VarName,@AlarmType)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@InsertTime",sysLog.InsertTime),
                new SqlParameter("@Note",sysLog.Note),
                new SqlParameter("@Operator",sysLog.Operator),
                new SqlParameter("VarName",sysLog.VarName),
                new SqlParameter("AlarmType",sysLog.AlarmType)
            };
           return  SQLHelper.ExecuteNonQuery(sql, sqlParameters);
        }
        #endregion
        #region 根据事件查值,返回查询到的第一个表
        public DataTable QuerySqlLogByCondition(string start,string end,string AlarmType)
        {
            string sql = "Select InsertTime,Note,Operator,VarName,AlarmType From SysLog " +
                         "Where COALESCE(" +
                         "TRY_CONVERT(datetime, InsertTime, 120)," +
                         "TRY_CONVERT(datetime, InsertTime)," +
                         "TRY_CONVERT(datetime, STUFF(STUFF(STUFF(CONVERT(nvarchar(50), InsertTime),11,1,' '),14,1,':'),17,1,':'), 120)" +
                         ") Between @start And @end";
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@start", Convert.ToDateTime(start)),
                new SqlParameter("@end", Convert.ToDateTime(end)),
            };
            if (AlarmType.Length > 0)
            {
                sql += " And CHARINDEX(@AlarmType, REPLACE(REPLACE(LTRIM(RTRIM(ISNULL(AlarmType,''))), CHAR(9), ''), N'　', '')) > 0";
                sqlParameters.Add(new SqlParameter("@AlarmType", AlarmType.Trim())); 
            }
            DataSet dataSet = SQLHelper.GetDataSet(sql,sqlParameters.ToArray());
            try
            {
                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
            }
            catch
            {
                return null;
            }
            return null;
        }
        #endregion
    }
}
