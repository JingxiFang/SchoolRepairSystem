using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairsClient.Bll;

namespace RepairsClient
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
            ReproterBll bll = new ReproterBll();
            int pos = 0;
            if (bll.Logining(userNmae, pwd))
            {
                //将用户名存到cookie 中
                HttpCookie cookie = new HttpCookie("cookie_userName");
                cookie.Expires = DateTime.Now.AddDays(365);
                cookie.Value = userNmae;
                context.Response.Cookies.Add(cookie);
                pos = 1;
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