using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairsClient.Model;

namespace RepairsClient.Dal
{
    public class WorkerDal
    {
        /// <summary>
        /// 通过id获取工人的名字
        /// </summary>
        /// <param name="id">工人id</param>
        /// <returns>工人名字</returns>
        public string GetWorkerNameByID(string id)
        {
            string strSql = "select name from workerinfo where workId ='" + id + "'";
            return SqlHelper.ExecuteScalar(strSql).ToString();
        }
    }
}
