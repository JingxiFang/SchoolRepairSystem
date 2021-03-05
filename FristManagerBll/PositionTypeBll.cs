using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FristManager.Model;
using FristManager.Dal;

namespace FristManager.Bll
{
    public class PositionTypeBll
    {
        PositionTypeDal dal=new PositionTypeDal ();

        /// <summary>
        /// 查询所有的职位信息
        /// </summary>
        /// <returns>职位对象</returns>
        public List<PositionType> GetAllType()
        {
            return dal.GetAllType();
        }
    }
}
