using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using FristManager.Dal;

namespace FristManager.Bll
{
    public class FaultInfoBll
    {
        FaultInfoDal infoDal = new FaultInfoDal();

        /// <summary>
        /// 获取显示在列表中的故障信息
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="typeId">故障类型</param>
        /// <returns>故障信息</returns>
        public List<FaultInfo> RoughFaultInfo(string typeId, string state)
        {

            return infoDal.RoughFaultInfo(state, typeId);
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
