using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepairsClient
{
    /// <summary>
    /// Test1 的摘要说明
    /// </summary>
    public class Test1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          
            string userID = context.Request["userId"];
            string friID = context.Request["friId"];


            HttpCookie cookie_userId = new HttpCookie("cookie_userId");
            cookie_userId.Value = userID;
            cookie_userId.Expires = DateTime.Now.AddDays(10);
            context.Response.Cookies.Add(cookie_userId);


            HttpCookie cookie_friId = new HttpCookie("cookie_friId");
            cookie_friId.Value = friID;
            cookie_friId.Expires = DateTime.Now.AddDays(10);
            context.Response.Cookies.Add(cookie_friId);

            context.Response.Redirect("Chact.htm");
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