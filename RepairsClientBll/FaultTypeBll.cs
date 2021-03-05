using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairsClient.Dal;
using RepairsClient.Model;
namespace RepairsClient.Bll
{
    
    public class FaultTypeBll
    {

        FaultTypeDal dal=new FaultTypeDal ();
          /// <summary>
        /// 获取没有故障类型信息
        /// </summary>
        /// <param name="delflag">删除标识</param>
        /// <returns>故障类型集合</returns>
        public List<FaultType> SelectIDandName(int delfalg)
        {
            return dal.SelectIDandName(delfalg);
        }

          /// <summary>
        /// 通过id获取故障类型描述信息
        /// </summary>
        /// <param name="id">类型id</param>
        /// <returns>类型描述</returns>
        public string GetTypeNoteById(int id)
        {
            return dal.GetTypeNoteById(id);
        }
    }
}
