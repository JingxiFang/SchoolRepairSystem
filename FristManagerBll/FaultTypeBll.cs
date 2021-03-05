using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Dal;
using FristManager.Model;

namespace FristManager.Bll
{
    public class FaultTypeBll
    {
        FaultTypeDal dal = new FaultTypeDal();
        /// <summary>
        /// 查询所有的故障类型信息
        /// </summary>
        /// <returns>故障类型对象</returns>
        public List<FaultType> GetAllType()
        {
            return dal.GetAllType();
        }
    }
}
