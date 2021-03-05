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
    /// PeoPleInfoDetailed 的摘要说明
    /// </summary>
    public class PeoPleInfoDetailed : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            WorkerBll bll = new WorkerBll();
            Worker worker = new Worker();
            string workid = context.Request["workerId"];
            
            //去数据库中查询
            worker=bll.DetaildtSelectWorkerInfo(workid,1);
            
            //去数据库中查询故障类型和职位类型
            //职位信息
            PositionTypeBll posBll=new PositionTypeBll ();
            List<PositionType> listPos = new List<PositionType>();
            listPos = posBll.GetAllType();
            StringBuilder strPos = new StringBuilder();
            for (int i = 0; i < listPos.Count; i++)
            {
                strPos.Append(" <option");
                if (listPos[i].PosId== Convert.ToInt32(worker.PosId))
                {
                    strPos.Append(" selected='selected' ");
                }
                strPos.Append(" value='"+listPos[i].PosId+"'>"+listPos[i].PosName+"</option>");             
            }

            string posid = worker.PosId;
            string managerPosId=(Convert.ToInt32(posid)+1).ToString();
            //管理者select
            string strManager = HtmlHelper.GetSelectManager(managerPosId, worker.TypeId);

            //故障类型信息
            FaultTypeBll typeBll = new FaultTypeBll();
            List<FaultType> listFaultType = new List<FaultType>();
            listFaultType = typeBll.GetAllType();
            StringBuilder strFaultType = new StringBuilder();
            for (int i = 0; i < listFaultType.Count; i++)
            {
                strFaultType.Append("<option");
                if (listFaultType[i].TypeId== Convert.ToInt32(worker.TypeId))
                {
                    strFaultType.Append(" selected='selected' ");
                }
                strFaultType.Append(" value='" + listFaultType[i].TypeId + "'>" + listFaultType[i].TypeName + "</option>");                      
            }

            StringBuilder strHtml = new StringBuilder();
            strHtml.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><link href='CSS/bootstrap.min.css' rel='stylesheet' type='text/css' /><script src='JS/bootstrap.min.js' type='text/javascript'></script><script src='JS/jquery-1.7.1.min.js' type='text/javascript'></script><link href='CSS/AHA.css' rel='stylesheet' type='text/css' />");
            strHtml.Append(" <script type='text/javascript'>function ChangeDisplayPosition() { $('#spanPos').css('display', 'none');$('#imgPosUp').css('display', 'none'); $('#selPos').css('display', 'block');$('#imgPosSure').css('display', 'block'); }function ChangeDisplayWorkType() {$('#spanType').css('display', 'none'); $('#imgTypeUp').css('display', 'none');$('#selType').css('display', 'block'); $('#imgTypeSure').css('display', 'block'); }function ChangeDisplayManagerId() { $('#spanManagerId').css('display', ' none');  $('#imgManagerIdUp').css('display', 'none'); $('#txtManagerId').css('display', ' block'); $('#imgManagerIdSure').css('display', 'block'); }");

            strHtml.Append("function UpdatePosition() { var posId = $('#selPos').val();if(posId=='0'){alert('请选择职位');return;} $.post('Update.ashx','action=1&workId=" + workid + "&postId=' + posId, function (msg) {if (msg == 1) { window.location.href = 'PeoPleInfoDetailed.ashx?workerId=" + workid + "'; }else { alert('修改失败，请稍后重试') ; } }) }");
            strHtml.Append("  function UpdateWorkType() {var typeId = $('#selType').val();if(typeId=='0'){alert('请选择类型');return;} $.post( 'Update.ashx','action=2&workId=" + workid + "&typeId=' + typeId,function (msg) { if (msg == 1) { window.location.href = 'PeoPleInfoDetailed.ashx?workerId=" + workid + "';} else { alert('修改失败，请稍后重试'); } })}");
           
                strHtml.Append(" function UpdateManagerId() {var managerId = $('#txtManagerId').val();if(managerId=='0'){window.location.href = 'PeoPleInfoDetailed.ashx?workerId=" + workid + "';}else{ $.post(  'Update.ashx', 'action=3&workId=" + workid + "&managerId=' + managerId, function (msg) {if (msg == 1) {  alert('修改成功'); window.location.href = 'PeoPleInfoDetailed.ashx?workerId=" + workid + "'; }  else {  alert('修改失败，请稍后重试');  }  }  )} } ");
        
            strHtml.Append("</script>");
            strHtml.Append("</head><body style='background-color: #ccd8f6'><center>  <div style='background: #ffffff; white: 100px' class='OnTop'><img src='images/详细资料.png' /></div><div> <div style='height: 100px'> </div>");
            if(worker.Photo.Equals("UserPhoto/暂无"))
            {
                strHtml.Append("<img src='images/维修主管头像.png' style='height:400px' class='img-circle'>");
            }
            else
            {
                strHtml.Append("<img src='" + worker.Photo + "' style='height:400px' class='img-circle'>");
            }
            
           strHtml.Append("<div style='height: 100px'> </div></div><span style='font-size: 40px; float: left'>工作相关：</span> <br /><br /><br /><div style='width: 90%; background: #ffffff'><table align='center' class='table' style='color: Gray; font-size: 50px;'> <tr><td>工号： </td><td> "+worker.Id+"</td> <td></td></tr>");
            strHtml.Append("<tr><td>姓名：</td> <td> "+worker.Name+"</td> <td> </td></tr>");
            strHtml.Append("<tr style='color: Black'> <td>类型： </td> <td><span id='spanType' style='display: block;'>"+worker.TypeName+"</span> <select id='selType' style='display: none; float: inherit; width: 70%; font-size: 50px'><option value='0'>请选择</option>");
            strHtml.Append(strFaultType);
            strHtml.Append(" </select></td><td> <img id='imgTypeUp' onclick='javascript:ChangeDisplayWorkType()' style='width: 50px; display: block' src='images/刷新.png' /> <img id='imgTypeSure' onclick='javascript:UpdateWorkType()' style='width: 50px; display: none' src='images/对号.png' /></td></tr>");
            strHtml.Append("<tr style='color: Black'> <td> 职位：</td><td><span id='spanPos' style='display: block'>"+worker.PosName+"</span><select id='selPos' style='display: none; float: inherit; width: 70%; font-size: 50px'> <option value='0'>请选择</option>");
            strHtml.Append(strPos);
            strHtml.Append("</select> </td>  <td><img id='imgPosUp' onclick='javascript:ChangeDisplayPosition()' style='width: 50px; display: block' src='images/刷新.png' /><img id='imgPosSure' onclick='javascript:UpdatePosition()' style='width: 50px; display: none' src='images/对号.png' /> </td> </tr>");
            strHtml.Append(" <tr style='color: Black'> <td>管理人：</td><td><span id='spanManagerId' style='display: block'>" + worker.ManagerName + "</span>");
           
                 strHtml.Append("<select id='txtManagerId' style='width: 100%;font-size: 50px; float: right;display:none'><option value='0'>请选择</option>");
      //strHtml.Append("<input type='text' id='txtManagerId' name='txtManagerId' value='' style=' float:inherit; display:none' /></td>");
            strHtml.Append(strManager);
            strHtml.Append("</select><td> <img id='imgManagerIdUp' onclick='javascript:ChangeDisplayManagerId()' style='width: 50px;    display: block' src='images/刷新.png' /><img id='imgManagerIdSure' onclick='javascript:UpdateManagerId()' style='width: 50px; display: none' src='images/对号.png' /> ");
            
           
            strHtml.Append("    </td> </tr> <tr><td>联系方式： </td> <td>" + worker.Phone + "</td> <td></td> </tr>");
            strHtml.Append("  <tr><td> 入职时间： </td>  <td> " + worker.EntryTime + "</td><td> </td> </tr></table>");
       strHtml.Append(" </div><span style='font-size: 35px; float: left'>基础信息：</span> <br /><br /> <br /><div style='width: 90%; background: #ffffff'> <table align='center' class='table' style='color: Gray; font-size: 50px;'> <tr> <td> 证件号码： </td> <td>"+worker.IdCard+"</td></tr>");
            strHtml.Append("<tr><td>家庭住址： </td> <td>"+worker.Address+" </td> </tr>");
            strHtml.Append("<tr> <td> 出生日期：</td> <td> " + worker.Brithday+ " </td>   </tr></table></div></center></body></html>");
 
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