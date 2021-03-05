using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using System.Data;
using System.Data.SqlClient;

namespace FristManager.Dal
{
    public class WorkerDal
    {
        /// <summary>
        /// 粗略的查询工人的信息
        /// </summary>
        /// <param name="typeId">类型id</param>
        /// <param name="postId">职位id</param>
        /// <returns>工人集合</returns>
        public List<Worker> RoughSelectWorkInfo(string typeId, string postId)
        {
            string strsql = "exec proc_RoughSelectWorkInfo " + typeId + "," + postId;
            List<Worker> listWorker = new List<Worker>();
            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteTable(strsql);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listWorker.Add(RowToWorker(dt.Rows[i]));
                    }
                }
            }
            return listWorker;
        }

        /// <summary>
        /// 把行转换成对象
        /// </summary>
        /// <param name="dataRow">某一行</param>
        /// <returns>工人对象</returns>
        private Worker RowToWorker(DataRow dataRow)
        {
            Worker worker = new Worker();
            worker.Id = dataRow["workid"].ToString();
            worker.Phone = dataRow["PhoneNum"].ToString();
            worker.Name = dataRow["name"].ToString();
            worker.Photo = "UserPhoto/" + dataRow["photo"].ToString();

            return worker;
        }


        private Worker RowToWorker(DataRow dataRow, int flag)
        {
            Worker worker = new Worker();
            worker.Id = dataRow["workid"].ToString();
            worker.Phone = dataRow["PhoneNum"].ToString();
            worker.Name = dataRow["workername"].ToString();
            worker.Photo = "UserPhoto/" + dataRow["photo"].ToString();
            DateTime entryTime = Convert.ToDateTime(dataRow["EntryTime"]);
            worker.EntryTime = entryTime.ToString("yyyy-MM-dd");
            worker.Remark = dataRow["Remark"].ToString();
            worker.PosName = dataRow["PosName"].ToString();
            worker.IdCard = dataRow["IdCard"].ToString();
            worker.Address = dataRow["Address"].ToString();
            DateTime bri = Convert.ToDateTime(dataRow["Brithday"]);
            worker.Brithday = bri.ToString("yyyy-MM-dd");
            worker.PosId = dataRow["posid"].ToString();

            if (flag == 1)
            {
                worker.TypeId = dataRow["type"].ToString();
                worker.TypeName = dataRow["TypeName"].ToString();
                worker.ManagerName = dataRow["managerName"].ToString();
            }
            return worker;
        }
        /// <summary>
        /// 详细的查询维修主管或者维修工的信息
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <returns>工人对象</returns>
        public Worker DetaildtSelectWorkerInfo(string workerid, int flag)
        {
            Worker worker = new Worker();
            DataTable dt = new DataTable();
            string strSql = "";
            //查询维修主管或者工人
            if (flag == 1)
            {
                strSql = "exec proc_DetailedSelectWorkerInfo '" + workerid + "'";
            }
            else if (flag == 2)
            {

                strSql = " exec proc_DetailedSelectWorkerInfoOfManager '" + workerid + "'";
            }
            dt = SqlHelper.ExecuteTable(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        worker = RowToWorker(dt.Rows[i], flag);
                    }
                }
            }
            return worker;
        }


        /// <summary>
        /// 详细的查询员工信息
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <returns>员工对象</returns>
        public Worker DetaildtSelectWorkerInfoOfManager(string workerid)
        {
            string strSql = "exec proc_DetailedSelectWorkerInfo '" + workerid + "'";
            Worker worker = new Worker();

            DataTable dt = new DataTable();
            dt = SqlHelper.ExecuteTable(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        worker = RowToWorkerFour(dt.Rows[i]);
                    }
                }
            }
            return worker;

        }

        private Worker RowToWorkerFour(DataRow dataRow)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 主管插入一条工人的信息
        /// </summary>
        /// <param name="manager">维修主管对象</param>
        /// <returns>是否成功</returns>
        public bool ManagerInsertOneManagerInfo(Worker manager)
        {
            string sqlStr = "declare @res int exec @res=proc_insertManagerWork @workID,@posId,@TypeId,@name,@idCard,@phone,@managerId select @res";
            SqlParameter[] sp ={
                                  new SqlParameter("@workID",manager.Id),
                                  new SqlParameter("@posId",manager.PosId),
                                  new SqlParameter("@TypeId",manager.TypeId),
                                  new SqlParameter("@name",manager.Name),
                                  new SqlParameter("@idCard",manager.IdCard),
                                  new SqlParameter("@phone",manager.Phone),
                                  new SqlParameter("@managerId",manager.ManagerId)
                              };

            int res = Convert.ToInt32(SqlHelper.ExecuteScalar(sqlStr, sp));
            if (res == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <param name="typeID">类型id</param>
        /// <returns>是否成功</returns>
        public bool UpdateTypeID(string workerid, string typeID)
        {
            string strSql = "update worker set Type=" + typeID + " where workId='" + workerid + "' ";
            return SqlHelper.ExecuteNonQuery(strSql) > 0;

        }

        /// <summary>
        /// 修改工人的职位
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <param name="posID">职位编号</param>
        /// <returns>是否成功</returns>
        public bool UpdatePosID(string workerid, string posID)
        {
            string strSql = "update worker set posID=" + posID + " where workId='" + workerid + "' ";
            return SqlHelper.ExecuteNonQuery(strSql) > 0;
        }

        /// <summary>
        /// 修改工人管理人id
        /// </summary>
        /// <param name="workerid">工人id</param>
        /// <param name="managerID">管理人id</param>
        /// <returns>是否成功</returns>
        public bool UpdateManagerID(string workerid, string managerID)
        {
            string strSql = "update worker set managerID='" + managerID + "' where workId='" + workerid + "' ";
            return SqlHelper.ExecuteNonQuery(strSql) > 0;
        }


        /// <summary>
        /// 工人自己修改信息
        /// </summary>
        /// <param name="worker">工人对象</param>
        /// <returns>是否成功</returns>
        public bool UpdateSelfInfo(Worker worker)
        {
            string strSql = "update WorkerInfo set name=@name,Address=@Address,Brithday=@Brithday,IdCard=@IdCard,Remark=@Remark,PhoneNum=@PhoneNum where workId=@workId";
            SqlParameter[] sp ={
                                  new SqlParameter("@name",worker.Name),
                                  new SqlParameter("@Address",worker.Address),
                                  new SqlParameter("@Brithday",worker.Brithday),
                                  new SqlParameter("@IdCard",worker.IdCard),
                                  new SqlParameter("@Remark",worker.Remark),
                                  new SqlParameter("@PhoneNum",worker.Phone),

                                  new SqlParameter("@workId",worker.Id),
                              };
            return SqlHelper.ExecuteNonQuery(strSql, sp) > 0;
        }




        /// <summary>
        /// 查询特定职位特定类型的工人姓名和id
        /// </summary>
        /// <param name="posId">职位id</param>
        /// <param name="typeId">类型id</param>
        /// <returns>工人集合</returns>
        public List<Worker> SelectManagerNameAndIdByPosIdAndTypeId(string posId, string typeId)
        {
            string strSql = "exec proc_SelectManagerNameAndIdByPosIdAndTypeId " + posId + "," + typeId;
            List<Worker> listManager = new List<Worker>();
            DataTable dt = SqlHelper.ExecuteTable(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listManager.Add(RowToWorkerThere(dt.Rows[i]));
                    }
                }
            }
            return listManager;

        }
        /// <summary>
        /// 查询特定职位特定类型的工人姓名和id
        /// </summary>
        /// <param name="posId">职位id</param> 
        /// <returns>工人集合</returns>
        public List<Worker> SelectManagerNameAndIdByPosIdAndTypeId(string posId)
        {
            string strSql = "exec proc_SelectManagerNameAndIdByPosIdAndTypeIdTwo " + posId;
            List<Worker> listManager = new List<Worker>();
            DataTable dt = SqlHelper.ExecuteTable(strSql);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listManager.Add(RowToWorkerThere(dt.Rows[i]));
                    }
                }
            }
            return listManager;

        }


        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        private Worker RowToWorkerThere(DataRow dataRow)
        {
            Worker worker = new Worker();
            worker.Name = dataRow["name"].ToString();
            worker.Id = dataRow["workid"].ToString();
            return worker;
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Logining(string name, string pwd)
        {
            string strSql = "declare @pos int exec  @pos=Proc_workIdandIDcard @workid,@idcard select  @pos";
            SqlParameter[] sp ={
                                        new SqlParameter("@workid",name),
                                        new SqlParameter("@idcard",pwd)
            };
            return Convert.ToInt32( SqlHelper.ExecuteScalar(strSql, sp));
        }



    }
}
