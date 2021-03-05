using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairsClient.Model;
using RepairsClient.Bll;
using System.Web.Script.Serialization;

namespace RepairsClient
{
    /// <summary>
    /// PersonalCenterPage 的摘要说明
    /// </summary>
    public class PersonalCenterPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            ReproterBll bll = new ReproterBll();
            string action = context.Request["action"];
            string reproterId = context.Request.Cookies["cookie_userName"].Value;
            if (action.Equals("1"))
            {
                List<Reproter> listRpe = new List<Reproter>();
                listRpe.Add( bll.selectPhoneNumber(reproterId));
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string resStr = jss.Serialize(listRpe);
                context.Response.Write(resStr);
            }
            else if (action.Equals("2"))
            {
                //接收到id和新的号码
                
                string number = context.Request["newNumber"];
                //修改
                
                if (bll.updatePhoneNum(reproterId, number))
                {
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
            }
            
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