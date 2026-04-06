using MTHHelper;
using MTHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.DataConvertLib;

namespace MTHProject
{
    public  class CommonMethods
    {
        /// <summary>
        /// 创建设备静态对象
        /// </summary>
        public static Device Device { get; set; }
        /// <summary>
        /// 创建一个静态的系统委托对象
        /// </summary>
        public static Action<int, string> AddLog;
        /// <summary>
        /// 创建连接类静态对象
        /// </summary>
        public static ModbusTCP modbus;
        /// <summary>
        /// 当前登录的管理员对象
        /// </summary>
        public static SysAdmin CurrentAdmin;
        /// <summary>
        /// 确定大小端
        /// </summary>
        public static DataFormat dataFormat = DataFormat.ABCD;
        /// <summary>
        /// 根据变量名从设备通信组中查找对应的变量对象。
        /// </summary>
        /// <param name="VarName">变量名称（与配置中的 <c>VarName</c> 一致）。</param>
        /// <returns>找到时返回对应的 <see cref="Variable"/>，未找到返回 <c>null</c>。</returns>
        public static Variable FindVar(string VarName)
        {
            foreach(Group item in Device.GroupList)
            {
                var res = item.VarList.Find(v => v.VarName == VarName);
                if (res != null)
                {
                    return res;
                }
            }
            return null;
        }
        /// <summary>
        /// 按变量名将输入值写入到从站对应地址，并根据变量类型自动进行转换后下发。
        /// </summary>
        /// <param name="varName">要改变的数据的名称</param>
        /// <param name="varValue">修改后的变量值</param>
        /// <returns>写入成功返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public static bool CommonWrite(string varName,string varValue)
        {
            //先找变量
            var variable=FindVar(varName);
            if (variable != null)
            {
                //获取变量的数据类型
                DataType dataType = (DataType)Enum.Parse(typeof(DataType),variable.DataType,true);
                //获取要写入的数据
                var result = MigrationLib.SetMigrationValue(varValue, dataType, variable.Scale.ToString(), variable.Offset.ToString());
                if (result.IsSuccess)
                {
                    //第四步:写入数据
                    try
                    {
                        switch (dataType)
                        {
                            case DataType.Bool:
                                return modbus.PreSetSingleCoil(variable.StartIndex, Convert.ToBoolean(result.Content));
                            case DataType.Short:
                                return modbus.PreSetSingleRegister(variable.StartIndex, Convert.ToInt16(result.Content));
                            case DataType.UShort:
                                return modbus.PreSetSingleRegister(variable.StartIndex, Convert.ToUInt16(result.Content));
                            case DataType.Int:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(result.Content), dataFormat));
                            case DataType.UInt:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(result.Content), dataFormat));
                            case DataType.Float:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(result.Content), dataFormat));
                            case DataType.Double:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(result.Content), dataFormat));
                            case DataType.Long:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(result.Content), dataFormat));
                            case DataType.ULong:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(result.Content), dataFormat));
                            case DataType.String:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromString(result.Content, Encoding.ASCII));
                            case DataType.ByteArray:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromHexString(result.Content));
                            case DataType.HexString:
                                return modbus.PreSetMultiRegisters(variable.StartIndex, ByteArrayLib.GetByteArrayFromHexString(result.Content));
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

            }
            return false;
        }
    }
}
