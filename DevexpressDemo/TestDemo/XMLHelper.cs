using System;
using System.Data;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TestDemo
{
    public static class XmlHelper
    {
        #region CreateXML

        /// <summary>
        /// 生成XML文件及对应的XSD文件
        /// </summary>
        /// <param name="strFileName"></param>
        public static void CreateXML(string strFileName)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ID", Type.GetType("System.String")),
                new DataColumn("NAME", Type.GetType("System.String")),
                new DataColumn("PARENTID", Type.GetType("System.String"))
            });
            dt.Rows.Add("", "", "");
            ds.Tables.Add(dt);
            ds.WriteXml(GetXmlFullPath(strFileName+".XML"));
            ds.WriteXmlSchema(GetXmlFullPath(strFileName+".XSD"));
            DeleteXmlAllRows(strFileName + ".XML");//清空XML
        }

        #endregion CreateXML

        #region GetXmlFullPath

        /// <summary>
        /// 返回完整路径
        /// </summary>
        /// <param name="strFileName">Xml的路径 </param>
        /// <returns></returns>
        public static string GetXmlFullPath(string strFileName)
        {
            //如果路径中含有:符号，则认定为传入的是完整路径
            if (strFileName.IndexOf(":") > 0)
            {
                return strFileName;
            }
            else
            {
                //返回完整路径
                return Application.StartupPath + "/" + strFileName;
            }
        }

        #endregion GetXmlFullPath

        #region GetDataSetByXml

        /// <summary>
        /// 读取xml直接返回DataSet
        /// </summary>
        /// <param name="strFileName">xml文件相对路径 </param>
        /// <returns></returns>
        public static DataSet GetDataSetByXml(string strFileName)
        {
            try
            {
                DataSet ds = new DataSet();
                //读取XML到DataSet
                ds.ReadXml(GetXmlFullPath(strFileName));

                if (ds.Tables.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion GetDataSetByXml

        #region GetDataViewByXml

        /// 〈summary〉
        /// 读取Xml返回一个经排序或筛选后的DataView
        /// 〈/summary〉
        /// 〈param name="strFileName"〉〈/param〉
        /// 〈param name="strWhere"〉筛选条件，如："name = ＇kgdiwss＇"〈/param〉
        /// 〈param name="strSort"〉排序条件，如："Id desc"〈/param〉
        /// 〈returns〉〈/returns〉
        public static DataView GetDataViewByXml(string strFileName, string strWhere, string strSort)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(strFileName));
                //创建DataView来完成排序或筛选操作
                DataView dv = new DataView(ds.Tables[0]);
                if (strSort != null)
                {
                    //对DataView中的记录进行排序
                    dv.Sort = strSort;
                }
                if (strWhere != null)
                {
                    //对DataView中的记录进行筛选，找到我们想要的记录
                    dv.RowFilter = strWhere;
                }
                return dv;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion GetDataViewByXml

        #region WriteXmlByDataSet

        /// <summary>
        /// 向Xml文件插入数据
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="dt_NEWTABLE"></param>
        /// <param name="operateType"></param>
        /// <returns></returns>
        public static bool WriteXmlByDataSet(string strFileName,DataTable dt_NEWTABLE,string operateType)
        {
            try
            {
                //根据传入的XML路径得到.XSD的路径，两个文件放在同一个目录下
                string strXDDFileName = strFileName.Substring(0, strFileName.IndexOf(".")) + ".xsd";
                DataSet ds = new DataSet();
                //读xml架构，关系到列的数据类型
                ds.ReadXmlSchema(GetXmlFullPath(strXDDFileName));
                ds.ReadXml(GetXmlFullPath(strFileName));
                DataTable dt = ds.Tables[0];
                if (operateType.ToUpper() == "ONE")
                {
                    if (dt.Rows.Count>0&&!string.IsNullOrEmpty(dt.Rows[0]["ID"].ToString()))
                    {
                        //在原来的表格基础上创建新行
                        DataRow[] dr = dt.Select("ID =" + dt_NEWTABLE.Rows[0]["ID"].ToString());
                        if (dr.Length != 0)
                        {
                            return false;
                        }
                        
                    }
                    dt.ImportRow(dt_NEWTABLE.Rows[0]);
                    dt.AcceptChanges();
                }
                else if (operateType.ToUpper() == "ALL")
                {
                    foreach (DataRow dr in dt_NEWTABLE.Rows)
                    {
                        dt.ImportRow(dr);
                        dt.AcceptChanges();
                    }
                }
                ds.AcceptChanges();
                ds.WriteXml(GetXmlFullPath(strFileName));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion WriteXmlByDataSet

        #region UpdateXmlRow

        /// <summary>
        /// 更新符合条件的一条Xml记录
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="dt_New"></param>
        /// <param name="dt_OLD"></param>
        /// <returns></returns>
        public static bool UpdateXmlRow(string strFileName, DataTable dt_New,DataTable dt_OLD)
        {
            try
            {
                //同上一方法
                string strXDDFileName = strFileName.Substring(0, strFileName.IndexOf(".")) + ".xsd";
                DataSet ds = new DataSet();
                //读xml架构，关系到列的数据类型
                ds.ReadXmlSchema(GetXmlFullPath(strXDDFileName));
                ds.ReadXml(GetXmlFullPath(strFileName));
                //先判断行数
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果当前记录为符合Where条件的记录
                        if (ds.Tables[0].Select("ID =" + dt_OLD.Rows[0]["ID"].ToString()).Length != 0)
                        {
                            //循环给找到行的各列赋新值
                            foreach(DataColumn dataColumn in ds.Tables[0].Columns)
                            {
                                ds.Tables[0].Select("ID =" + dt_OLD.Rows[0]["ID"].ToString())[0][dataColumn.ToString()] = dt_New.Rows[0][dataColumn.ToString()].ToString();
                            }
                            //更新DataSet
                            ds.AcceptChanges();
                            //重新写入XML文件
                            ds.WriteXml(GetXmlFullPath(strFileName));
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion UpdateXmlRow

        #region DeleteXmlAllRows

        /// 〈summary〉
        /// 删除所有行
        /// 〈/summary〉
        /// 〈param name="strFileName"〉XML路径〈/param〉
        /// 〈returns〉〈/returns〉
        public static bool DeleteXmlAllRows(string strFileName)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(strFileName));
                //如果记录条数大于0
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //移除所有记录
                    ds.Tables[0].Rows.Clear();
                }
                //重新写入，这时XML文件中就只剩根节点了
                ds.WriteXml(GetXmlFullPath(strFileName));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion DeleteXmlAllRows

        #region DeleteXmlRowByIndex

        /// 〈summary〉
        ///  删除指定行
        /// 〈/summary〉
        /// 〈param name="strFileName"〉〈/param〉
        /// 〈param name="iDeleteRow"〉要删除的行在DataSet中的ID值集合〈/param〉
        public static bool DeleteXmlRowByIndex(string strFileName, List<int> iDeleteRow)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(strFileName));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach(int ID in iDeleteRow)
                    {
                        if (ds.Tables[0].Select("ID =" + ID.ToString()).Length != 0)
                        {
                            //删除符合条件的行
                            ds.Tables[0].Select("ID =" + ID.ToString())[0].Delete();
                        }
                    }
                }
                ds.WriteXml(GetXmlFullPath(strFileName));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion DeleteXmlRowByIndex

        #region DeleteXmlRows

        /// 〈summary〉
        /// 删除strColumn列中值为ColumnValue的行
        /// 〈/summary〉
        /// 〈param name="strFileName"〉xml相对路径〈/param〉
        /// 〈param name="strColumn"〉列名〈/param〉
        /// 〈param name="ColumnValue"〉strColumn列中值为ColumnValue的行均会被删除〈/param〉
        /// 〈returns〉〈/returns〉
        public static bool DeleteXmlRows(string strFileName, string strColumn, string[] ColumnValue)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(strFileName));
                //先判断行数
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //判断行多还是删除的值多，多的for循环放在里面
                    if (ColumnValue.Length > ds.Tables[0].Rows.Count)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ColumnValue.Length; j++)
                            {
                                //找到符合条件的行
                                if (ds.Tables[0].Rows[i][strColumn].ToString().Trim().Equals(ColumnValue[j]))
                                {
                                    //删除行
                                    ds.Tables[0].Rows[i].Delete();
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < ColumnValue.Length; j++)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                //找到符合条件的行
                                if (ds.Tables[0].Rows[i][strColumn].ToString().Trim().Equals(ColumnValue[j]))
                                {
                                    //删除行
                                    ds.Tables[0].Rows[i].Delete();
                                }
                            }
                        }
                    }

                    ds.WriteXml(GetXmlFullPath(strFileName));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion DeleteXmlRows
    }
}
