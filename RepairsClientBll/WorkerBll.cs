using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairsClient.Model;
using RepairsClient.Dal;

namespace RepairsClient.Bll
{
    public class WorkerBll
    {
        WorkerDal dal = new WorkerDal();
        /// <summary>
        /// 通过id获取工人的名字
        /// </summary>
        /// <param name="id">工人id</param>
        /// <returns>工人名字</returns>
        public string GetWorkerNameByID(string id)
        {
            return dal.GetWorkerNameByID(id).ToString();
        }
    }
}
