using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using RepairsClient.Model;
using RepairsClient.Bll;
using System.IO;

namespace RepairsClient
{
    /// <summary>
    /// Chact 的摘要说明
    /// </summary>
    public class Chact :IHttpHandler
    {
       
        //当前用户昵称
        protected string userName = "李华";
        //当前用户ID
        protected string userId = "J1502709";

        //朋友id
        protected string friID = "A2016001";
        protected string friName = "小红";
        //当前页面地址
        protected string pageUrl = "";
        //消息列表
        private static IList<Msg> MsgList = new List<Msg>();
        //消息唯一标识
        private static int MsgIndex = 1;

        WorkerBll workerBll = new WorkerBll();
        ReproterBll repBll = new ReproterBll();

        public void ProcessRequest(HttpContext context)
        {
            userId = context.Request.Cookies["cookie_userId"].Value;
            friID = context.Request.Cookies["cookie_friId"].Value;
            userName = context.Request.Cookies["cookie_userName"].Value;
            friName = GetName(friID);
            if (string.IsNullOrEmpty(friName))
            {
                //Response.Write("系统异常，正集合猴子们正在为您解决bug");
                context.Response.Redirect("Error.htm");
            }
           // pageUrl = "IM.aspx" + System.Web.HttpContext.Current.Request.Url.Query;

           
           
                context.Response.ContentType = "text/plain";
                if (context.Request.Params["lastIndex"] != null)
                {
                    //获取未读信息
                    int lastIndex = -1;
                    if (context.Request.Params["lastIndex"] != "")
                    {
                        lastIndex = int.Parse(context.Request.Params["lastIndex"]);
                    }
                    string str = GetMsg(lastIndex);
                    context.Response.Write(str);
                    context.Response.End();
                }
                else if (context.Request.Params["uname"] != null)
                {
                    //发送信息
                    AddMsg(context.Request.Params["uname"], context.Request.Params["content"], friID);
                    context.Response.End();
                }
                else
                {
                    //pageUrl = "IM.aspx" + System.Web.HttpContext.Current.Request.Url.Query;
                    //初始化，从cookie中获取昵称
                    if (context.Request.Cookies["cookie_userName"] != null)
                    {
                        userName = context.Request.Cookies["cookie_userName"].Value;
                    }
                    else
                    {
                        userName = userId;
                    }
                }

        }

        /// <summary>
        /// 根据id返回名字
        /// </summary>
        /// <param name="id">学号/工号</param>
        /// <returns>姓名</returns>
        private string GetName(string id)
        {
            object nameObj = repBll.GetReproterNamebyID(id);
            string name = "";
            if (nameObj != null)
            {
                name = nameObj.ToString();
            }
            else
            {
                name = workerBll.GetWorkerNameByID(id);
            }
            return name;
        }


        //添加消息
        private void AddMsg(string user, string content, string to)
        {
            //将昵称记入cookie
            //HttpCookie cookie = new HttpCookie("cookie_userName");
            //cookie.Expires = DateTime.Now.AddDays(365);
            //cookie.Value = user;
            //Response.Cookies.Add(cookie);

            Msg item = new Msg();
            MsgIndex++;
            item.userId = userId;
            item.index = MsgIndex;
            item.dt = DateTime.Now;
            item.user = user;
            item.content = content;
            item.to = to;

            /*------*/
            item.toUser = friName;
            /*----------*/

           // item.group = Request.Url.Query;
           
            
            
            MsgList.Add(item);

            if (MsgList.Count > 5000)
            {
                //防止消息列表数据超过5000条
                for (int i = 0; i < MsgList.Count - 5000; i++)
                {
                    MsgList.RemoveAt(0);
                }
            }
        }

        //获取消息
        private string GetMsg(int lastIndex)
        {
            //MsgIndex消息唯一标识
            string strReturn = MsgIndex.ToString();
            int j = 0;
            for (int i = MsgList.Count - 1; i >= 0; i--)
            {
                ////只显示同组信息    //这个判断什么？
                //if (MsgList[i].group != Request.Url.Query)
                //{
                //    continue;
                //}

                ////显示自己发的消息，显示给我的消息，显示公共消息
                //if (!string.IsNullOrEmpty(MsgList[i].to) && MsgList[i].to != friID && MsgList[i].userId != userId )
                //{
                //    continue;
                //}
                //发过来的消息
                if ((MsgList[i].to.Equals(userId) && MsgList[i].userId.Equals(friID)) || (MsgList[i].to.Equals(friID) && MsgList[i].userId.Equals(userId)))
                {
                    //获取未读的最近100条消息
                    if (lastIndex < MsgList[i].index)
                    {
                        if (j++ > 100)
                        {
                            break;
                        }
                        // <时间>用户昵称>id>内容>是否公开>对谁说  
                        strReturn += "<" + MsgList[i].ToString();
                    }
                }
            }

            return strReturn;
        }




        /// <summary>
        /// 消息类
        /// </summary>
        public class Msg
        {
            /// <summary>
            /// 消息ID
            /// </summary>
            public int index;

            /// <summary>
            /// 消息时间
            /// </summary>
            public DateTime dt;

            /// <summary>
            /// 发送人ID
            /// </summary>
            public string userId;

            /// <summary>
            /// 发送人昵称
            /// </summary>
            public string user;

            /// <summary>
            /// 内容
            /// </summary>
            public string content;

            /// <summary>
            /// 组
            /// </summary>
            public string group;

            /// <summary>
            /// 接收者ID 当为空时为公共消息
            /// </summary>
            public string to;

            /// <summary>
            /// 接收者昵称
            /// </summary>
            public string toUser;

            /// <summary>
            /// 拼接消息
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                //时间     用户昵称    id     内容    是否公开    对谁说  
                string strReturn = dt.ToString("yyyy-MM-dd HH:mm:ss");
                strReturn += ">" + FormatPara(user);
                strReturn += ">" + userId;
                strReturn += ">" + FormatPara(content);
                strReturn += ">" + to;
                strReturn += ">" + FormatPara(toUser);
                return strReturn;
            }

            //格式化HTML
            private string FormatPara(string str)
            {
                str = str.Replace("&", "&amp;");
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                return str;
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