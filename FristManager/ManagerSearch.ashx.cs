using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FristManager.Bll;
using FristManager.Model;
using System.Text;

namespace FristManager
{
    /// <summary>
    /// ManagerSearch 的摘要说明
    /// </summary>
    public class ManagerSearch : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string typeid = context.Request["typeId"];
            string posId = context.Request["posId"];

            //拼接最上边的标题图片
            HtmlHelper htmlHelper = new HtmlHelper();
            string msg = htmlHelper.StrImg(typeid);

            List<Worker> listWorker = new List<Worker>();
            WorkerBll workerBll = new WorkerBll();
            listWorker = workerBll.RoughSelectWorkInfo(typeid, posId);
            StringBuilder strMain = new StringBuilder();
            for (int i = 0; i < listWorker.Count; i++)
            {
                strMain.Append("<div onclick='javascript:LoadDetailed(\"" + listWorker[i].Id + "\");'><table class='table table-condensed' style='font-size: 50px; width: 100%; height: 240px'><tr><td width='29%' rowspan='3'>");
                if (listWorker[i].Photo.Equals("UserPhoto/暂无"))
                {
                    strMain.Append("<img style='float: left;height:400px' src='images/维修主管头像.png' class='img-circle'  />");
                }
                else
                {
                    strMain.Append("<img style='float: left;height:400px' src='" + listWorker[i].Photo + "' class='img-circle' />");
                }

                strMain.Append("</td> <td width='60%'>" + listWorker[i].Name + " </td></tr>");
                strMain.Append("<tr><td>" + listWorker[i].Id + "</td></tr>");
                strMain.Append(" <tr><td>" + listWorker[i].Phone + " </td></tr></table> </div>");
            }

            //整个页面
            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><link href='CSS/bootstrap.css' rel='stylesheet' type='text/css' /> <link href='CSS/bootstrap.min.css' rel='stylesheet' type='text/css' /> <link href='CSS/AHA.css' rel='stylesheet' type='text/css' />");
            strHtml.Append("<script type='text/javascript'>function LoadDetailed(id) { window.location.href = 'PeoPleInfoDetailed.ashx?workerId='+id;} function AddSomeOne() { window.location.href = 'AddSecondManager.ashx?action=1&posid=" + posId + "&typeid=" + typeid + "'; }</script>");
            strHtml.Append("</head><body style='background: #ccd8f6'> <center> <div id='Div1' class='OnTop'>");
            strHtml.Append(msg);
            strHtml.Append("</div> <div style='height:150px'></div> <div id='bigDiv' style='width: 90%'>");
            strHtml.Append(strMain);
            strHtml.Append(" </div> <div class='OnBottomNoBackground'><button id='btnAdd' onclick='javascript:AddSomeOne();' type='button' class='btn btn-default btnAdd'><span style='font-size: 50px'>添加</span></button></div></center></body></html>");

            context.Response.Write(strHtml.ToString());
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