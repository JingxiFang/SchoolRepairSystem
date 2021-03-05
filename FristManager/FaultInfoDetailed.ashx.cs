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
    /// FaultInfoDetailed 的摘要说明
    /// </summary>
    public class FaultInfoDetailed : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string id = context.Request["id"];
            FaultInfoBll bll = new FaultInfoBll();
            FaultInfo info = bll.SelectFaultInfoById(Convert.ToInt32(id));
            StringBuilder htmlContent = new StringBuilder();
            htmlContent.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><link href='CSS/bootstrap.css' rel='stylesheet' type='text/css' /><script src='JS/bootstrap.min.js' type='text/javascript'></script> <script src='JS/jquery-1.7.1.min.js' type='text/javascript'></script><link href='CSS/AHA.css' rel='stylesheet' type='text/css' /></head><body style='background: #ccd8f6'><center> <div id='divBig' style='border: solid 1px blue;  width: 100%'>  <center>  <div id='Div1' class='OnTop'><img   src='images/故障详情标题.png' /></div></center> <div style='height: 85px'> </div><table  style=' background:#e6ecfc'  class='table'> <tr class='active'><td> <span style='font-size: 35px;'>故障信息 </td><td> </td> </tr><tr><td><span style='font-size: 30px'>故障单号</td>");
            htmlContent.Append("<td><span style='font-size: 30px'>" + info.FaultId + " </td></tr>");
            htmlContent.Append("<tr> <td><span style='font-size: 30px'>报修时间</td>");
            htmlContent.Append(" <td><span style='font-size: 30px'>" + info.SubTime + "</td></tr><tr><td> <span style='font-size: 30px'>损坏物品</td>");
            htmlContent.Append("<td><span style='font-size: 30px'>" + info.FaultPro + "</td></tr>");
            htmlContent.Append("<tr><td><span style='font-size: 30px'>故障地点</td>");
            htmlContent.Append(" <td><span style='font-size: 30px'>" + info.Site + "</td> </tr>");
            htmlContent.Append(" <tr><td><span style='font-size: 30px'>故障原因 </td>");
            htmlContent.Append("<td><span style='font-size: 30px'>" + info.FaultReason + "</td></tr>");
            htmlContent.Append("<tr><td><span style='font-size: 30px'>故障详情</td>");
            htmlContent.Append(" <td><span style='font-size: 30px'>" + info.DesCribe + "</td></tr>");
            htmlContent.Append("<tr><td><span style='font-size: 30px'>声音</td>");
            htmlContent.Append("<td>" + info.VoicePath + "</td></tr>");
            htmlContent.Append(" <tr> <td> <span style='font-size: 30px'>图片</td>");
            htmlContent.Append("<td></td></tr></table>");
            htmlContent.Append("<table style=' background:#e6ecfc' class='table'><tr class='active'><td><span style='font-size: 35px;'>维修进度</td> <td><button type='button' class='btn btn-primary btn-xs'> <span style='font-size: 25px;'>  查看详情</button></td></tr> <tr><td colspan='2'><span style='font-size: 30px'>" + info.StateTime + " &nbsp &nbsp   " + info.State + "</td></tr></table>");

            if (!string.IsNullOrEmpty(info.Evaluate))
            {
                htmlContent.Append("<table style=' background:#e6ecfc' class='table'><tr class='active'><td><span style='font-size: 35px;'>评价</td> <td><button type='button' class='btn btn-primary btn-xs'> <span style='font-size: 25px;'>  查看详情</button></td></tr> <tr><td colspan='2'><span style='font-size: 30px'>" + "星星等级：" + info.EvaluateStar + "<br/>" + "评语" + info.Evaluate + "</td></tr></table>");
            }
            htmlContent.Append("<table style=' background:#e6ecfc' class='table table-condensed'><tr class='active'><td colspan='2'><span style='font-size: 35px'>维修人员信息</td></tr><tr style=' background:#e0e8fc '><td  colspan='2'>&nbsp <span style='font-size: 30px'>维修工信息</td></tr>");
            htmlContent.Append("<tr><td><span style='font-size: 25px'>" + info.WorkerName + "</td> <td><button type='button' class='btn btn-primary btn-xs'><span style='font-size: 25px;'> 联系他</button></td></tr>");
            htmlContent.Append(" <tr><td><span style='font-size: 25px'>联系方式</td><td><span style='font-size: 25px'>" + info.WorkerPhoneNum + " </td></tr>");
            htmlContent.Append("  <tr style=' background:#e0e8fc '><td colspan='2'> <span style='font-size: 30px'>维修主管信息</td></tr>");
            htmlContent.Append("<tr><td> <span style='font-size: 25px'>" + info.ManagerName + "</td>");
            htmlContent.Append("<td><button type='button' class='btn btn-primary btn-xs'><span style='font-size: 25px;'>  联系他 </button></td></tr>");
            htmlContent.Append("<tr><td><span style='font-size: 25px'>联系方式</td><td> <span style='font-size: 25px'>" + info.ManagerPhoneNum + "</td></tr>");
            htmlContent.Append(" </table</div></center></body></html>");


            context.Response.Write(htmlContent.ToString());






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