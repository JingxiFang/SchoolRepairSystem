using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using FristManager.Dal;

namespace FristManager.Bll
{
    public class WorkerBll
    {
        WorkerDal dal = new WorkerDal();


        /// <summary>
        /// 粗略的查询工人的信息
        /// </summary>
        /// <param name="typeId">类型id</param>
        /// <param name="postId">职位id</param>
        /// <returns>工人集合</returns>
        public List<Worker> RoughSelectWorkInfo(string typeId, string postId)
        {
            return dal.RoughSelectWorkInfo(typeId, postId);
        }


        /// <summary>
        /// 主管插入一条维修主管的信息
        /// </summary>
        /// <param name="manager">维修主管对象</param>
        /// <returns>是否成功</returns>
        public bool ManagerInsertOneManagerInfo(Worker manager)
        {
            return dal.ManagerInsertOneManagerInfo(manager);
        }

        /// <summary>
        /// 详细的查询维修主管或者维修工的信息
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <returns>工人对象</returns>
        public Worker DetaildtSelectWorkerInfo(string workerid,int flag)
        {
            return dal.DetaildtSelectWorkerInfo(workerid, flag);
        }


         /// <summary>
        /// 修改类型
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <param name="typeID">类型id</param>
        /// <returns>是否成功</returns>
        public bool UpdateTypeID(string workerid, string typeID)
        {
            return dal.UpdateTypeID(workerid, typeID);
        }


         /// <summary>
        /// 修改工人的职位
        /// </summary>
        /// <param name="workerid">工号</param>
        /// <param name="posID">职位编号</param>
        /// <returns>是否成功</returns>
        public bool UpdatePosID(string workerid, string posID)
        {
            return dal.UpdatePosID(workerid, posID);
        }


        /// <summary>
        /// 修改工人管理人id
        /// </summary>
        /// <param name="workerid">工人id</param>
        /// <param name="managerID">管理人id</param>
        /// <returns>是否成功</returns>
        public bool UpdateManagerID(string workerid, string managerID)
        {
            return dal.UpdateManagerID(workerid, managerID);
        }


        /// <summary>
        /// 查询特定职位特定类型的工人姓名和id
        /// </summary>
        /// <param name="posId">职位id</param>
        /// <param name="typeId">类型id</param>
        /// <returns>工人集合</returns>
        public List<Worker> SelectManagerNameAndIdByPosIdAndTypeId(string posId, string typeId)
        {
            return dal.SelectManagerNameAndIdByPosIdAndTypeId(posId, typeId);
        }


        /// <summary>
        /// 查询特定职位特定类型的工人姓名和id
        /// </summary>
        /// <param name="posId">职位id</param>
        /// <returns>工人集合</returns>
        public List<Worker> SelectManagerNameAndIdByPosIdAndTypeId(string posId)
        {
            return dal.SelectManagerNameAndIdByPosIdAndTypeId(posId);
        }


         /// <summary>
        /// 工人自己修改信息
        /// </summary>
        /// <param name="worker">工人对象</param>
        /// <returns>是否成功</returns>
        public bool UpdateSelfInfo(Worker worker)
        {
            return dal.UpdateSelfInfo(worker);
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Logining(string name, string pwd)
        {
            return dal.Logining(name, pwd);
        }
    }
}
