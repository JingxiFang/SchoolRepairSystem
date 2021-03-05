using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FristManager.Model;
using FristManager.Bll;

namespace FristManager
{
    /// <summary>
    /// Update 的摘要说明
    /// </summary>
    public class Update : IHttpHandler
    {
        WorkerBll bll = new WorkerBll();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            string workid = context.Request["workId"];
            bool msg = false;
            switch (action)
            {
                case"1":
                    string  postId=context.Request["postId"];
                    msg = UpdatePosID(workid, postId);
                    break;
                case "2":
                    string typeId=context.Request["typeId"];
                    msg = UpdateTypeID(workid, typeId);
                    break;
                case "3":
                    string managerId = context.Request["managerId"];
                    msg = UpdateManagerID(workid, managerId);
                    break;
                case "4":
                    msg= UpdateInfo(context);
                    break;
            }
            if (msg)
            {
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("2");
            }
           
        }

        /// <summary>
        /// 修改个人的信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns>是否成功</returns>
        private bool UpdateInfo(HttpContext context)
        {
           //先获取信息
            Worker worker = new Worker();
            worker.Id = context.Request["workid"];
            worker.IdCard = context.Request["idcard"];
            worker.Name = context.Request["name"];
            worker.Phone = context.Request["phone"];
            worker.Remark = context.Request["remark"];
            worker.Brithday = context.Request["brithday"];
            worker.Address = context.Request["address"];
            return bll.UpdateSelfInfo(worker);
        }

        //修改类型
        private bool UpdateTypeID(string workerid, string typeID)
        {
            return bll.UpdateTypeID(workerid, typeID);

        }
        //修改职位
        private bool UpdatePosID(string workerid, string posID)
        {
            return bll.UpdatePosID(workerid,posID);
        }
        //修改管理人id
        private bool UpdateManagerID(string workerid, string managerID)
        {
            return bll.UpdateManagerID(workerid, managerID);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}