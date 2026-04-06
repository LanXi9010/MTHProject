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
    public class ActualDataService
    {
        public int AddActualData(ActualData actualData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Insert into ActualData(InsertTime,Station1Temp,Station1Humidity,");
            stringBuilder.Append("Station2Temp,Station2Humidity,Station3Temp,Station3Humidity,");
            stringBuilder.Append("Station4Temp,Station4Humidity,Station5Temp,Station5Humidity,");
            stringBuilder.Append("Station6Temp,Station6Humidity) Values(@InsertTime,@Station1Temp,@Station1Humidity,");
            stringBuilder.Append("@Station2Temp,@Station2Humidity,@Station3Temp,@Station3Humidity,");
            stringBuilder.Append("@Station4Temp,@Station4Humidity,@Station5Temp,@Station5Humidity,");
            stringBuilder.Append("@Station6Temp,@Station6Humidity)");
            SqlParameter[] sqlParameters = new SqlParameter[]
{
                new SqlParameter("@InsertTime",actualData.InsertTime),
                new SqlParameter("@Station1Temp",actualData.Station1Temp),
                new SqlParameter("@Station1Humidity",actualData.Station1Humidity),
                new SqlParameter("@Station2Temp",actualData.Station2Temp),
                new SqlParameter("@Station2Humidity",actualData.Station2Humidity),
                new SqlParameter("@Station3Temp",actualData.Station3Temp),
                new SqlParameter("@Station3Humidity",actualData.Station3Humidity),
                new SqlParameter("@Station4Temp",actualData.Station4Temp),
                new SqlParameter("@Station4Humidity",actualData.Station4Humidity),
                new SqlParameter("@Station5Temp",actualData.Station5Temp),
                new SqlParameter("@Station5Humidity",actualData.Station5Humidity),
                new SqlParameter("@Station6Temp",actualData.Station6Temp),
                new SqlParameter("@Station6Humidity",actualData.Station6Humidity)

};
            return SQLHelper.ExecuteNonQuery(stringBuilder.ToString(), sqlParameters);
        }
        public DataTable QueryActualDataByCondition(string start, string end, List<string> columns)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Select InsertTime,");

            stringBuilder.Append(string.Join(",", columns));

            stringBuilder.Append(" from ActualData where InsertTime between @Start and @End");
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@Start",start),
                new SqlParameter("@End",end),
            };
            try
            {
                DataSet dataSet = SQLHelper.GetDataSet(stringBuilder.ToString(), sqlParameters);

                if (dataSet.Tables.Count > 0)
                {
                    return dataSet.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

