using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairsClient.Bll;
using RepairsClient.Model;
using System.Web.Script.Serialization;

namespace RepairsClient
{
    /// <summary>
    /// FaultRepair 的摘要说明
    /// </summary>
    public class FaultRepair : IHttpHandler
    {
       
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string action=context.Request["action"];
            FaultTypeBll faultTypeBll = new FaultTypeBll();
            if (action == null)
            {
                FaultInfoBll infoBll = new FaultInfoBll();
                FaultInfo info = new FaultInfo();
                info.TypeId = Convert.ToInt32(context.Request["selectType"]);
                info.Site = context.Request["TextPlace"];
                info.FaultPro = context.Request["TextPro"];
                info.DesCribe = context.Request["textNote"];
                info.FaultReason = context.Request["textReason"];
                info.SubPeoId = context.Request.Cookies["cookie_userName"].Value;
                info.State = "1";
                if (infoBll.InsterOneInfo(info) > 0)
                {
                    context.Response.Write(1);
                }
                else
                {
                    context.Response.Write(0);
                }

            }
            else if (action.Equals("typeinfo"))
            {
                List<FaultType> listType=new List<FaultType>();
                listType= faultTypeBll.SelectIDandName(1);
                JavaScriptSerializer jss = new JavaScriptSerializer();
                string resStr = jss.Serialize(listType);
                context.Response.Write(resStr);
            }
            else if (action.Equals("typenote"))
            {  
                string id = context.Request["id"];
                string note = faultTypeBll.GetTypeNoteById(Convert.ToInt32(context.Request["id"]));
                context.Response.Write(note);
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