using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairsClient.Dal;
using RepairsClient.Model;

namespace RepairsClient.Bll
{
    public class FaultInfoBll
    {
        FaultInfoDal infoDal = new FaultInfoDal();
        
        /// <summary>
        /// 添加评价内容 改变状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rank"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool UpdateEvaluateByFaultId(string id, string rank, string content)
        {
            return infoDal.UpdateEvaluateByFaultId(id, rank, content);
        }

        /// <summary>
        /// 插入一条新的故障信息
        /// </summary>
        /// <param name="info">故障信息对象</param>
        /// <returns>受影响的行数</returns>
        public int InsterOneInfo(FaultInfo info)
        {
            return infoDal.InsterOneInfo(info);
        }

        /// <summary>
        /// 获取列表中显示的故障信息
        /// </summary>
        /// <param name="state">状态编号</param>
        /// <returns>故障信息</returns>
        public List<FaultInfo> RoughFaultInfo(int state, string reportId)
        {
            return infoDal.RoughFaultInfo(state, reportId);
        }


        /// <summary>
        /// 通过故障编号获取故障信息
        /// </summary>
        /// <param name="falutId"></param>
        /// <returns></returns>
        public FaultInfo SelectFaultInfoById(int falutId)
        {
            return infoDal.SelectFaultInfoById(falutId);
        }
    }
}
