using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using FristManager.Bll;
using FristManager.Model;

namespace FristManager
{
    /// <summary>
    /// AddScondManager 的摘要说明
    /// </summary>
    public class AddScondManager : IHttpHandler
    {
        WorkerBll bll = new WorkerBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string typeid = context.Request["typeid"];
            string action = context.Request["action"];
            string posId = context.Request["posid"];
            int posIdInt =Convert.ToInt32( context.Request["posid"]);
            string strManager = "";
            string managerPosId = (Convert.ToInt32(posId) + 1).ToString();
            if ((posIdInt + 1) == 3)
            {
                strManager = HtmlHelper.GetSelectManager(managerPosId);
            }
            else
            {
                strManager = HtmlHelper.GetSelectManager(managerPosId, typeid);
            }


                if (action.Equals("1"))
                {
                    StringBuilder strHtml = new StringBuilder();
                    strHtml.Append("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title></title><script src='JS/jquery-1.7.1.min.js' type='text/javascript'></script><script src='JS/bootstrap.min.js' type='text/javascript'></script><link href='CSS/bootstrap.css' rel='stylesheet' type='text/css' /><link href='CSS/bootstrap.min.css' rel='stylesheet' type='text/css' /><link href='/CSS/AHA.css' rel='stylesheet' type='text/css' />");
                    strHtml.Append(" <script type='text/javascript'>$(document).ready(function () { $('#btnSure').click(function () {var managerName = $('#txtName').val(); var managerIdCard = $('#txtIdCard').val();var managerPhone = $('#txtPhone').val();var managerId = $('#selectManager').val();alert(managerName+managerIdCard+managerPhone+managerId); var falg=0;if (managerName == '') { $('#divwarning').text('请填写姓名');show(); falg=falg+1;}else if (managerIdCard == '') {  $('#divwarning').text('请填写身份证号码'); show();  falg=falg+1;}else if (managerPhone == '') {$('#divwarning').text('请填写手机号码');show(); falg=falg+1;} else if (managerId == '0') {$('#divwarning').text('请选择管理人');show(); falg=falg+1;} setTimeout(function () { $('#divAlterNo').css('display', 'none'); }, 3000); if(falg==0){$.post( 'AddSecondManager.ashx','typeid=" + typeid + "&posid=" + posId + "&action=2&name=' + managerName + '&idCade=' + managerIdCard + '&phone=' + managerPhone + '&managerid=' + managerId, function (msg) { window.location.href = 'ManagerSearch.ashx?action=1&posid=" + posId + "&typeId=" + typeid + "'; }); }}); $('#btnCancel').click(function () { window.location.href = 'ManagerSearch.ashx?action=1&posId=2&typeId=" + typeid + "'; }); });  function show() { $('#divAlterNo').css('display', 'block');  }</script>");
                    strHtml.Append("<body style='background: #ccd8f6'><center><div style='width: 100%'><img style='width: 100%' src='images/添加员工标题.png' /></div> <div style='height: 150px'></div><div style='width: 80%'><div class='input-group  input-group-lg' style='height: 100px'><span class='input-group-addon' style='font-size: 45px' >姓名</span> <input type='text' class='form-control' placeholder='请输入真实姓名' style='height: 100px;font-size: 45px' id='txtName'></div> <div class='input-group  input-group-lg' style='height: 100px'><span class='input-group-addon' style='font-size: 45px'>身份证号码</span> <input id='txtIdCard' type='text' class='form-control' placeholder='请输入正确的身份证号码' style='height: 100px;font-size: 45px'> </div><div class='input-group  input-group-lg' style='height: 100px'><span class='input-group-addon' style='font-size: 45px'>联系方式</span> <input id='txtPhone' type='text' class='form-control' placeholder='请输入11位手机号码' style='height: 100px; font-size: 45px'> </div>   <div class='input-group  input-group-lg' style='height: 100px'><span class='input-group-addon' style='font-size: 45px'>manager</span>");
                    strHtml.Append("<select id='selectManager' style='width: 100%;font-size: 50px; float: right'><option value='0'>请选择</option>");
                    strHtml.Append(strManager);
                    strHtml.Append(" </select></div><div style='height: 300px'> </div><div style='display: none; float: inherit' id='divAlterNo' class='alert alert-warning'> <span id='divwarning' style='font-size: 40px;'></span> </div><div><button id='btnCancel' type='button' class='btn btn-default btnSureOrCancle'><span style='font-size: 45px'>取消 </span> </button>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp &nbsp&nbsp&nbsp<button id='btnSure' type='button' class='btn btn-default btnSureOrCancle'><span style='font-size: 45px'>确定 </span></button></div></div></center></body></html>");

                    context.Response.Write(strHtml.ToString());
                }
                else if (action.Equals("2"))
                {
                    Worker worker = new Worker();
                    worker.PosId = posId;
                    worker.TypeId = typeid;

                    worker.Name = context.Request["name"];
                    worker.IdCard = context.Request["idCade"];
                    //随机获取工号
                    worker.Id = GetWorkerId(typeid);
                    worker.Phone = context.Request["phone"];
                    worker.ManagerId = context.Request["managerid"];
                    //插入到数据库中 
                    while (!bll.ManagerInsertOneManagerInfo(worker))
                    {
                        worker.Id = GetWorkerId(typeid);
                    }
                }
        }

        /// <summary>
        /// 随机获取工号
        /// </summary>
        /// <returns>随机工号</returns>
        private string GetWorkerId(string typeid)
        {
            string workID = "";
            switch (typeid)
            {
                case "1":
                    workID += "A";
                    break;
                case "2":
                    workID += "B";
                    break;
                case "3":
                    workID += "C";
                    break;
                case "4":
                    workID += "D";
                    break;
            }
            workID += DateTime.Now.Year.ToString();
            Random ran = new Random();
            int rnum = ran.Next(100, 999);
            workID += rnum.ToString();
            return workID;

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