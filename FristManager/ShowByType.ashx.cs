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
    /// ShowByType 的摘要说明
    /// </summary>
    public class ShowByType : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request["action"];
            string typeId = context.Request["typeId"];

            HtmlHelper htmlHelper = new HtmlHelper();
            string msg=htmlHelper.StrImg(typeId);

            string state = context.Request["State"];
            FaultInfoBll faultInfoBll = new FaultInfoBll();
            List<FaultInfo> listFaultInfo = new List<FaultInfo>();
            StringBuilder strTable = new StringBuilder();
            //加载维修单信息 
            listFaultInfo = faultInfoBll.RoughFaultInfo(typeId, state);
            for (int i = 0; i < listFaultInfo.Count; i++)
            {
                //
                strTable.Append(" <table style='top: 100px' id='BigTable' name='BigTable'>");
                strTable.Append("<tr><table width='700' class='table table-striped'>");
                strTable.Append("<tr><td  align='left'>");

                strTable.Append("</td> <td style='width: 240px'></td><td align='right'> </td></tr>");


                strTable.Append(" <tr><td colspan='3'>");
                strTable.Append(" <table width='680' height='216'>");
                strTable.Append("<tr align='center'><td width='250'><span style='font-size: 20px'>报修单号：</td> ");
                strTable.Append("<th colspan='2px'><span style='font-size: 20px'> " + listFaultInfo[i].FaultId + "</th></tr>");
                strTable.Append(" <tr align='center'> <td><span style='font-size: 20px'>故障地点：</td>");
                strTable.Append("  <th colspan='2px'><span style='font-size: 20px'>" + listFaultInfo[i].Site + "</th></tr>");
                strTable.Append("<tr align='center'>");
                strTable.Append("<td><span style='font-size: 20px'>损坏物件：</td>");
                strTable.Append("<th colspan='2px'><span style='font-size: 20px'>" + listFaultInfo[i].FaultPro + " </th> </tr>");
                strTable.Append("</table></td> </tr>");
                strTable.Append("<tr><td><span style='color: Red; font-size: 25px'>【状态】" + listFaultInfo[i].State + "</td>");
                strTable.Append("<td colspan='2' align='right'>");

                strTable.Append("<a href='FaultInfoDetailed.ashx?id=" + listFaultInfo[i].FaultId + "'><button type='button' class='btn btn-primary btn-xs' ><span style='font-size: 20px'>查看详情</button></a></td> </tr>");
                strTable.Append("</table></tr>");
                strTable.Append("</table>");
            }
            //return;
           



            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><script src='JS/bootstrap.min.js' type='text/javascript'></script><script src='JS/jquery-1.7.1.min.js' type='text/javascript'></script><link href='CSS/bootstrap.css' rel='stylesheet' type='text/css' /><link href='CSS/bootstrap.min.css' rel='stylesheet' type='text/css' /><link href='CSS/AHA.css' rel='stylesheet' type='text/css' /></head><body style='background-color: #ccd8f6'><center><div id='divBig' style='border: solid 1px blue;width: 100%'><center><div id='DivTitle' class='OnTop'>");
            strHtml.Append(msg);
            strHtml.Append(" </div></center><div style='height: 150px; width: 720px'></div><div id='DivTable'>");
            strHtml.Append(strTable);
            strHtml.Append(" </div><center><div class='OnBottom'> <ul class='nav nav-pills'>");
            if (state.Equals("1"))
            {
                strHtml.Append(" <li class='active'><a href='#' class='a_daohang'>未完成</a></li><li><a href='ShowByType.ashx?typeId=" + typeId + "&State=2' class='a_daohang'>待评价</a></li><li><a href='ShowByType.ashx?typeId=" + typeId + "&State=3' ' class='a_daohang'>全部</a></li></ul> </div></center></div><div style=' height:50px; width:100%'></div></div></center></body></html>");
            }
            else if (state.Equals("2"))
            {
                strHtml.Append("<li><a href='ShowByType.ashx?typeId=" + typeId + "&State=1' class='a_daohang'>未完成</a></li><li class='active'><a href='#' class='a_daohang'>待评价</a></li> <li><a href='ShowByType.ashx?typeId=" + typeId + "&State=3' class='a_daohang'>全部</a></li>");
            }
            else if (state.Equals("3"))
            {
                strHtml.Append("<li><a href='ShowByType.ashx?typeId=" + typeId + "&State=1' class='a_daohang'>未完成</a></li><li><a href='ShowByType.ashx?typeId=" + typeId + "&State=2' class='a_daohang'>待评价</a></li> <li <li class='active'><a href='#' class='a_daohang'>全部</a></li>");
            }

                

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