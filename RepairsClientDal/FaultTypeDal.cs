using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RepairsClient.Model;

namespace RepairsClient.Dal
{
    public class FaultTypeDal
    {
        /// <summary>
        /// 获取故障类型id和名称
        /// </summary>
        /// <param name="delflag">删除标识</param>
        /// <returns>故障类型集合</returns>
        public List<FaultType> SelectIDandName(int delfalg)
        {
            string strSql = "select Typeid ,TypeName from faultType where delfalg=" + delfalg;
            List<FaultType> listType = new List<FaultType>(); 
           DataTable table= SqlHelper.ExecuteTable(strSql);
           if (table != null)
           {
               if(table.Rows.Count>0)
               {
                   foreach (DataRow item in table.Rows)
                   {
                       listType.Add(GetDateInfo(item));
                   }   
               }
           }
           return listType;
        }
        /// <summary>
        /// 将行中的信息转换成type对象
        /// </summary>
        /// <param name="item">表中的每一行</param>
        /// <returns>type对象</returns>
        private FaultType GetDateInfo(DataRow item)
        {
            FaultType type=new FaultType ();
            type.TypeId = Convert.ToInt32(item["TypeId"]);
            type.TypeName = item["TypeName"].ToString();
           
            return type;
        }

        /// <summary>
        /// 通过id获取故障类型描述信息
        /// </summary>
        /// <param name="id">类型id</param>
        /// <returns>类型描述</returns>
        public string GetTypeNoteById(int id)
        {
            string strSql = "select note from faultType where delfalg=1 and typeid=" + id;
            return SqlHelper.ExecuteScalar(strSql).ToString();
        }
    }
}

