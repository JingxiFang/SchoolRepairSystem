using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairsClient.Model;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace RepairsClient.Dal
{
    public class FaultInfoDal
    {
        /// <summary>
        /// 添加评价内容 改变状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rank"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool UpdateEvaluateByFaultId(string id, string rank, string content)
        {
            string strSql="update FaultInfo set Evaluate='"+content+"' ,EvaluateStar="+rank+" ,State=5 where Faultid="+id;
            return SqlHelper.ExecuteNonQuery(strSql) > 0;
        
        }

        /// <summary>
        /// 插入一条新的故障信息
        /// </summary>
        /// <param name="info">故障信息对象</param>
        /// <returns>受影响的行数</returns>
        public int InsterOneInfo(FaultInfo info)
        {
            string strSql = "insert into FaultInfo(TypeId, SubTime, Site, DesCribe, PhotoPath, VoicePath, SubPeoId,FaultReason,FaultPro,state) values(@TypeId, @SubTime, @Site, @DesCribe, @PhotoPath, @VoicePath, @SubPeoId,@FaultReason,@FaultPro,@state)";
            SqlParameter[] param={
                                    new SqlParameter("@TypeId",info.TypeId) ,
                                    new SqlParameter("@SubTime",DateTime.Now),
                                    new SqlParameter("@Site",info.Site),
                                    new SqlParameter("@DesCribe",info.DesCribe),
                                    new SqlParameter("@PhotoPath",GetFolderName("Photo")),
                                    new SqlParameter("@VoicePath",GetFolderName("Voice")),
                                    new SqlParameter("@SubPeoId",info.SubPeoId),
                                    new SqlParameter("@FaultReason",info.FaultReason),
                                    new SqlParameter("@FaultPro",info.FaultPro), 
                                    new SqlParameter("@state",info.State)
                                 };
            return SqlHelper.ExecuteNonQuery(strSql, param);
 
        }


        /// <summary>
        /// 获取并创建要存放的文件夹
        /// </summary>
        /// <returns>路径</returns>
        private string GetFolderName(string type)
        {
            string path = @"C:\Users\张芳\Desktop\软件大赛资料\PhotoPath\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\" + DateTime.Now.Day + "\\" + DateTime.Now.Hour + "-" + DateTime.Now.Minute+type;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
 
        }

        /// <summary>
        /// 获取列表中显示的故障信息
        /// </summary>
        /// <param name="state">状态编号</param>
        /// <returns>故障信息</returns>
        public List<FaultInfo> RoughFaultInfo(int state,string reportId)
        {
            string strSql = "exec Pro_RoughSelectFaultInfo " + state + ",'" + reportId+"'";
            List<FaultInfo> listInfo = new List<FaultInfo>();
            DataTable table = SqlHelper.ExecuteTable(strSql);
            if (table != null)
            {
                if (table.Rows.Count >0)
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
            string strSql = "exec Proc_DetailedSelectFaultInfoOne " + falutId ;
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
            
            info.DesCribe = item["DesCribe"].ToString ();
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
