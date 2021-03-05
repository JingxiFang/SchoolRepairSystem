using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairsClient.Bll;
using RepairsClient.Model;
using System.Text;

namespace RepairsClient
{
    /// <summary>
    /// Evaluate 的摘要说明
    /// </summary>
    public class Evaluate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string id = context.Request["id"];
            string rank = context.Request["rank"];
            FaultInfoBll bll = new FaultInfoBll();
            if (string.IsNullOrEmpty(rank))
            {
                context.Response.ContentType = "text/html";
                FaultInfo info = bll.SelectFaultInfoById(Convert.ToInt32(id));
                StringBuilder htmlContent = new StringBuilder();
                htmlContent.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title> <link href='CSS/lrtk.css' rel='stylesheet' type='text/css' /><link href='CSS/bootstrap.min.css' rel='stylesheet' type='text/css' /><script src='JS/jquery-1.7.1.min.js' type='text/javascript'></script> <script src='JS/bootstrap.min.js' type='text/javascript'></script><script src='JS/lrtk.js' type='text/javascript'></script><link href='CSS/AHA.css' rel='stylesheet' type='text/css' /></head><body style='background-color: #ccd8f6'><center><div id='divBig' style='border: solid 1px blue; height: 1280px; width: 720px'><center> <div id='Div1' class='OnTop'><img width='720' src='images/保修评价.png' /></div></center><div style='height: 90px; width: 720px'></div> <div id='infoDiv'><table style='background: #e6ecfc' class='table'><tr class='active'><td><span style='font-size: 35px;'>故障信息</td><td></td>");
                htmlContent.Append("</tr><tr><td><span style='font-size: 30px'>故障单号</td><td id='faultID'><span style='font-size: 30px'>" + info.FaultId + "</td> </tr>");
                htmlContent.Append("<tr><td> <span style='font-size: 30px'>损坏物品 </td><td><span style='font-size: 30px'>" + info.FaultPro + "</td></tr>");
                htmlContent.Append("<tr><td><span style='font-size: 30px'>故障地点</td><td><span style='font-size: 30px'>" + info.Site + "</td></tr>");
                htmlContent.Append("</table></div><div class='' style='width: 720px;'><span style='font-size: 30px; float: left'>&nbsp&nbsp 先来亮起小星星吧:</span><div id='xzw_starSys'><div id='xzw_starBox'><ul class='star' id='star'><li><a href='javascript:void(0)' title='1' class='one-star'>1</a></li><li><a href='javascript:void(0)' title='2' class='two-stars'>2</a></li><li><a href='javascript:void(0)' title='3' class='three-stars'>3</a></li><li><a href='javascript:void(0)' title='4' class='four-stars'>4</a></li><li><a href='javascript:void(0)' title='5' class='five-stars'>5</a></li></ul><div class='current-rating' id='showb'></div></div></div></div><div id='EvaluateContent'><textarea id='txtEvaluate' name='txtEvaluate' cols='44' rows='10' style='font-size: 30px;color: #000000'></textarea><br /><br /><button type='button' id='btnCancle' class='btn btn-warning EvaluateBtn' style=' font-size: 30px'>取消</button> &nbsp &nbsp<button type='button' id='btnSubmit' class='btn btn-info EvaluateBtn' style=' font-size: 30px'>提交</button></div></div> </center></body></html>");
                context.Response.Write(htmlContent.ToString());
            }
            else
            {
                context.Response.ContentType = "text/plain";
                string content = context.Request["content"];
                if (bll.UpdateEvaluateByFaultId(id, rank, content))
                {
                    context.Response.Write(1);
                }
                else
                {
                    context.Response.Write(0);
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