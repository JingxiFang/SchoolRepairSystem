using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FristManager.Bll;
using FristManager.Model;
using System.Web.Script.Serialization;

namespace FristManager
{
    /// <summary>
    /// PersonalCenterPage 的摘要说明
    /// </summary>
    public class PersonalCenterPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

        string userId = context.Request.Cookies["cookie_userName"].Value;
            
            //先暂时固定
            //string userId = "Z2016001";
            //获取信息

            List<Worker> worker = new List<Worker>();
            WorkerBll workerBll = new WorkerBll();
            worker.Add(workerBll.DetaildtSelectWorkerInfo(userId,2));
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string resStr = jss.Serialize(worker);
            context.Response.Write(resStr);
            //context.Response.Write("Hello World");
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