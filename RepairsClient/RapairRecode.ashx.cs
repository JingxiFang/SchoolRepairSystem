using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepairsClient.Model;
using RepairsClient.Bll;
using System.Web.Script.Serialization;
using System.Text;

namespace RepairsClient
{
    /// <summary>
    /// RapairRecode 的摘要说明
    /// </summary>
    public class RapairRecode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            FaultInfoBll faultInfoBll = new FaultInfoBll();
            List<FaultInfo> listFaultInfo = new List<FaultInfo>();
            int state = Convert.ToInt32(action);
            string reportId = context.Request.Cookies["cookie_userName"].Value;
            StringBuilder strTable = new StringBuilder();
            //加载维修单信息 
            listFaultInfo = faultInfoBll.RoughFaultInfo(state, reportId);
            for (int i = 0; i < listFaultInfo.Count; i++)
            {
                //
                strTable.Append(" <table style='top: 100px' id='BigTable' name='BigTable'>");
                strTable.Append("<tr><table width='700' class='table table-striped'>");
                strTable.Append("<tr><td  align='left'><span style='font-size: 20px'>【维修工】");
                if(!string.IsNullOrEmpty( listFaultInfo[i].WorkerName))
                {
                    strTable.Append(listFaultInfo[i].WorkerName + "</td> <td style='width: 240px'></td><td align='right'> <button value='" + listFaultInfo[i].WorkerId + "' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModal'>联系他 </button></td></tr>");
                } 
                else
                {
                    strTable.Append("</td> <td style='width: 240px'></td><td align='right'> </td></tr>");
                }
                   
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
                if (state == 2)
                {
                    strTable.Append("<a href='Evaluate.ashx?id=" + listFaultInfo[i].FaultId + "'><button type='button' class='btn btn-primary btn-xs' ><span style='font-size: 20px'>评价</button>&nbsp</a>");
                }
                strTable.Append("<a href='FaultInfoDetailed.ashx?id=" + listFaultInfo[i].FaultId + "'><button type='button' class='btn btn-primary btn-xs' ><span style='font-size: 20px'>查看详情</button></a></td> </tr>");
                strTable.Append("</table></tr>");
                strTable.Append("</table>");
            }
            //return;
            context.Response.Write(strTable.ToString());


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