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
    public class SysAdminService
    {
        public  SysAdmin AdminLogin(SysAdmin sysAdmin)
        {
            string sql = "Select LoginId,ParamSet,Recipe,HistoryLog,HistoryTrend,UserManage";

            sql += " from SysAdmin where LoginName=@LoginName and LoginPwd=@LoginPwd";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName",sysAdmin.LoginName),
                new SqlParameter("@LoginPwd",sysAdmin.LoginPwd)
            };

            DataSet dataSet = SQLHelper.GetDataSet(sql, parameters);

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count == 1)
            {
                sysAdmin.LoginId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LoginId"]);
                sysAdmin.ParamSet = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["ParamSet"]);
                sysAdmin.Recipe = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["Recipe"]);
                sysAdmin.HistoryLog = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["HistoryLog"]);
                sysAdmin.HistoryTrend = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["HistoryTrend"]);
                sysAdmin.UserManage = Convert.ToBoolean(dataSet.Tables[0].Rows[0]["UserManage"]);
                return sysAdmin;
            }
            else
            {
                return null;
            }
        }
        public int AddSysAdmin(SysAdmin sysAdmin)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("insert into SysAdmin(LoginName,LoginPwd,ParamSet,Recipe,HistoryLog,HistoryTrend,UserManage)");
            stringBuilder.Append(" values(@LoginName,@LoginPwd,@ParamSet,@Recipe,@HistoryLog,@HistoryTrend,@UserManage)");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginName",sysAdmin.LoginName),
                new SqlParameter("@LoginPwd",sysAdmin.LoginPwd),
                new SqlParameter("@ParamSet",sysAdmin.ParamSet),
                new SqlParameter("@Recipe",sysAdmin.Recipe),
                new SqlParameter("@HistoryLog",sysAdmin.HistoryLog),
                new SqlParameter("@HistoryTrend",sysAdmin.HistoryTrend),
                new SqlParameter("@UserManage",sysAdmin.UserManage)
            };

            return SQLHelper.ExecuteNonQuery(stringBuilder.ToString(), sqlParameters);
        }
        public int DeleteSysAdmin(int loginId)
        {
            string sql = "Delete from SysAdmin where LoginId=@LoginId";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId)
            };
            return SQLHelper.ExecuteNonQuery(sql, sqlParameters);
        }
        public int ModifySysAdmin(SysAdmin sysAdmin)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Update SysAdmin set LoginName=@LoginName,LoginPwd=@LoginPwd,");

            stringBuilder.Append("ParamSet=@ParamSet,Recipe=@Recipe,");

            stringBuilder.Append("HistoryLog=@HistoryLog,HistoryTrend=@HistoryTrend,");

            stringBuilder.Append("UserManage=@UserManage where LoginId=@LoginId");

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoginId",sysAdmin.LoginId),
                new SqlParameter("@LoginName",sysAdmin.LoginName),
                new SqlParameter("@LoginPwd",sysAdmin.LoginPwd),
                new SqlParameter("@ParamSet",sysAdmin.ParamSet),
                new SqlParameter("@Recipe",sysAdmin.Recipe),
                new SqlParameter("@HistoryLog",sysAdmin.HistoryLog),
                new SqlParameter("@HistoryTrend",sysAdmin.HistoryTrend),
                new SqlParameter("@UserManage",sysAdmin.UserManage)

            };
            return SQLHelper.ExecuteNonQuery(stringBuilder.ToString(), sqlParameters);

        }
        public List<SysAdmin> QuerySysAdmins()
        {
            string sql = "Select LoginId,LoginName,LoginPwd,ParamSet,Recipe,HistoryLog,HistoryTrend,UserManage from SysAdmin";

            SqlDataReader sqlDataReader = SQLHelper.ExecuteReader(sql);

            List<SysAdmin> sysAdmins = new List<SysAdmin>();

            while (sqlDataReader.Read())
            {
                sysAdmins.Add(new SysAdmin()
                {
                    LoginId = Convert.ToInt32(sqlDataReader["LoginId"]),
                    LoginName = sqlDataReader["LoginName"].ToString(),
                    LoginPwd = sqlDataReader["LoginPwd"].ToString(),
                    ParamSet = Convert.ToBoolean(sqlDataReader["ParamSet"]),
                    Recipe = Convert.ToBoolean(sqlDataReader["Recipe"]),
                    HistoryLog = Convert.ToBoolean(sqlDataReader["HistoryLog"]),
                    HistoryTrend = Convert.ToBoolean(sqlDataReader["HistoryTrend"]),
                    UserManage = Convert.ToBoolean(sqlDataReader["UserManage"]),
                });
            }
            return sysAdmins;
        }
    }
}
