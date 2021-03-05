using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace FristManager.Dal
{
    public class FaultInfoDal
    {


        /// <summary>
        /// 获取显示在列表中的故障信息
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="typeId">故障类型</param>
        /// <returns>故障信息</returns>
        public List<FaultInfo> RoughFaultInfo( string typeId ,string state )
        {
            string strSql = "exec proc_SelectFauleByTypeIDAndStateId " + state + "," + typeId ;
            List<FaultInfo> listInfo = new List<FaultInfo>();
            DataTable table = SqlHelper.ExecuteTable(strSql);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow item in table.Rows)
                    {
                        listInfo.Add(RowToObjectOne(item));
                    }
                }
            }
            return listInfo;
        }

        /// <summary>
        /// 行中数据转换成故障信息对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private FaultInfo RowToObjectOne(DataRow item)
        {
            FaultInfo info = new FaultInfo();
            info.Site = item["Site"].ToString();
            info.State = item["StaName"].ToString();
            info.FaultPro = item["Faultpro"].ToString();
            info.FaultId = Convert.ToInt32(item["FaultId"]);

            if (item["name"] == null)
            {
                info.WorkerName = "暂无";
            }
            else
            {
                info.WorkerName = item["name"].ToString();
                info.WorkerId = item["Workerid"].ToString();
            }
            return info;
        }

        /// <summary>
        /// 通过故障编号获取故障信息
        /// </summary>
        /// <param name="falutId"></param>
        /// <returns></returns>
        public FaultInfo SelectFaultInfoById(int falutId)
        {
            string strSql = "exec Proc_DetailedSelectFaultInfoOne " + falutId;
            DataTable table = SqlHelper.ExecuteTable(strSql);
            FaultInfo info = new FaultInfo();
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    info = RowToObjectTwo(table.Rows[0]);
                }
            }
            return info;

        }

        private FaultInfo RowToObjectTwo(DataRow item)
        {
            FaultInfo info = new FaultInfo();
            info.Site = item["Site"].ToString();
            info.FaultPro = item["Faultpro"].ToString();
            info.FaultId = Convert.ToInt32(item["FaultId"]);

            info.DesCribe = item["DesCribe"].ToString();
            info.FaultReason = item["FaultReason"].ToString();
            info.PhotoPath = item["PhotoPath"].ToString();
            info.VoicePath = item["VoicePath"].ToString();
            info.State = item["StaName"].ToString();
            info.StateTime = Convert.ToDateTime(item["StateTime"]);
            info.SubTime = Convert.ToDateTime(item["SubTime"]);
            info.Evaluate = item["Evaluate"].ToString();
            string statNum = item["EvaluateStar"].ToString();
            if (!string.IsNullOrEmpty(statNum))
            {
                info.EvaluateStar = Convert.ToInt32(item["EvaluateStar"]);
            }
            else
            {
                info.EvaluateStar = 0;
            }


            info.ManagerName = item["ManagerName"].ToString();
            if (item["WorkerName"] == null)
            {
                info.WorkerName = "暂无";
            }
            else
            {
                info.WorkerName = item["WorkerName"].ToString();
            }
            info.ManagerPhoneNum = item["ManagerPhoneNum"].ToString();
            info.WorkerPhoneNum = item["WorkerPhoneNum"].ToString();
            return info;
        }
    }
}
