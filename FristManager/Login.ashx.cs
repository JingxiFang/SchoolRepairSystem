using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FristManager.Bll;
using FristManager.Model;

namespace FristManager
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //接收用户名和密码
            string userNmae = context.Request["name"];
            string pwd = context.Request["pwd"];
            //去数据库比较 
            WorkerBll bll = new WorkerBll();
            int pos =bll.Logining(userNmae, pwd);
            if (pos != 0) { 
            //将用户名存到cookie 中
                HttpCookie cookie = new HttpCookie("cookie_userName");
                cookie.Expires = DateTime.Now.AddDays(365);
                cookie.Value = userNmae;
                context. Response.Cookies.Add(cookie);
            }
            context.Response.Write(pos);
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