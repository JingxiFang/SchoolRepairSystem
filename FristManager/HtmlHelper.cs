using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using FristManager.Model;
using FristManager.Bll;

namespace FristManager
{
    public class HtmlHelper
    {

        /// <summary>
        /// 获取标题应该显示的图片
        /// </summary>
        /// <param name="typeId">类型id</param>
        /// <returns></returns>
        public string StrImg(string typeId)
        {
            string msg = "";
            switch (typeId)
            {
                case "4":
                    msg = "<img width='100%' src='images/基础设施标题.png' />";
                    break;
                case "1":
                    msg = "<img width='100%' src='images/电器设备标题.png' />";
                    break;
                case "2":
                    msg = "<img width='100%' src='images/多媒体标题.png' />";
                    break;
                case "3":
                    msg = "<img width='100%' src='images/公共卫生标题.png' />";
                    break;
            }
            return msg;

        }

        /// <summary>
        /// 查询管理人名称
        /// </summary>
        /// <param name="posId">职位</param>
        /// <param name="typeid">类型</param>
        /// <returns>select中的选项</returns>
        public static string GetSelectManager(string posId,string typeid)
        {
            WorkerBll bll = new WorkerBll();
           
            StringBuilder strManager = new StringBuilder();
            List<Worker> listWorker = bll.SelectManagerNameAndIdByPosIdAndTypeId(posId, typeid);
            for (int i = 0; i < listWorker.Count; i++)
            {
                strManager.Append("<option value='" + listWorker[i].Id + "' >" + listWorker[i].Name + "</option>");
            }
            return strManager.ToString();
        }



        public static string GetSelectManager(string posId)
        {
            WorkerBll bll = new WorkerBll();

            StringBuilder strManager = new StringBuilder();
            List<Worker> listWorker = bll.SelectManagerNameAndIdByPosIdAndTypeId(posId);
            for (int i = 0; i < listWorker.Count; i++)
            {
                strManager.Append("<option value='" + listWorker[i].Id + "' >" + listWorker[i].Name + "</option>");
            }
            return strManager.ToString();
        }
    }
}