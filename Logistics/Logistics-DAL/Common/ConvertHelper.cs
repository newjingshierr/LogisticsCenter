using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;

namespace Logistics_DAL
{
    public class ConvertHelper<T> where T : new()
    {
        public static List<T> DtToList(DataTable dt)
        {
            //定义集合
            List<T> ListCollection = new List<T>(dt.Rows.Count);
            //获得 T 模型类型
            Type T_type = typeof(T);
            //获得 T 模型类型公共属性
            PropertyInfo[] Proper = T_type.GetProperties();
            //临时变量，存储变量模型公共属性Name
            string Tempname = "";
            //遍历参数 DataTable的每行
            foreach (DataRow Dr in dt.Rows)
            {
                //实例化 T 模版类
                T t = new T();
                //遍历T 模版类各个属性
                #region
                foreach (PropertyInfo P in Proper)
                {
                    //取出类属性之一
                    Tempname = P.Name;
                    //判断DataTable中是否有此列
                    if (dt.Columns.Contains(Tempname))
                    {
                        //判断属性是否可写属性
                        if (!P.CanWrite)
                        {
                            continue;
                        }
                        try
                        {
                            //得到Datable单元格中的值
                            object value = Dr[Tempname];
                            //得到 T 属性类型
                            Type ProType = P.PropertyType;
                            //判断类型赋值
                            if (value != DBNull.Value)
                            {
                                //
                                if (value.GetType() == ProType)
                                {
                                    P.SetValue(t, value, null);
                                }
                                else
                                {
                                    if (ProType == typeof(string))
                                    {
                                        string Temp = value.ToString();
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(byte))
                                    {
                                        byte Temp = Convert.ToByte(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(short))
                                    {
                                        short Temp = short.Parse(value.ToString());
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(long))
                                    {
                                        long Temp = long.Parse(value.ToString());
                                        P.SetValue(t, Temp, null);
                                    }

                                    else if (ProType == typeof(Int64))
                                    {
                                        Int64 Temp = Convert.ToInt64(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(Int32))
                                    {
                                        Int32 Temp = Convert.ToInt32(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else if (ProType == typeof(Int16))
                                    {
                                        Int16 Temp = Convert.ToInt16(value);
                                        P.SetValue(t, Temp, null);
                                    }
                                    else
                                    {
                                        object Temp = Convert.ChangeType(value, ProType);
                                        P.SetValue(t, Temp, null);
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                #endregion
                ListCollection.Add(t);
            }
            return ListCollection;
        }

        public static T DtToModel(DataTable dt)
        {
            return DtToList(dt).FirstOrDefault();
        }
    }

}
