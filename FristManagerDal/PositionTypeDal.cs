using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using System.Data;

namespace FristManager.Dal
{
    public class PositionTypeDal
    {
        /// <summary>
        /// 查询所有的职位信息
        /// </summary>
        /// <returns>职位对象</returns>
        public List< PositionType> GetAllType()
        {
            string strSql = "select * from Position ";
            List<PositionType> listPos = new List<PositionType>();

            DataTable dt = SqlHelper.ExecuteTable(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        listPos.Add(RowToPos(item));
                    }
                }
            }
            return listPos;
            
 
        }

        private PositionType RowToPos(DataRow item)
        {
            PositionType pos = new PositionType();
            pos.PosId = Convert.ToInt32(item["PosId"]);
            pos.PosName = item["PosName"].ToString();
            return pos;
        }
    }
}
