using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using System.Data;

namespace FristManager.Dal
{
    public class FaultTypeDal
    {
        /// <summary>
        /// 查询所有的故障类型信息
        /// </summary>
        /// <returns>故障类型对象</returns>
        public List<FaultType> GetAllType()
        {
            string strSql = "select * from FaultType ";
            List<FaultType> listFaultType = new List<FaultType>();

            DataTable dt = SqlHelper.ExecuteTable(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        listFaultType.Add(RowToType(item));
                    }
                }
            }
            return listFaultType;
        }

        private FaultType RowToType(DataRow item)
        {
            FaultType ft = new FaultType();
            ft.TypeId = Convert.ToInt32(item["typeId"]);
            ft.TypeName = item["typeName"].ToString();
            return ft;
        }
    }
}
