using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RepairsClient.Dal;
using RepairsClient.Model;

namespace RepairsClient.Bll
{
    public class ReproterBll
    {
        ReproterDal dal = new ReproterDal();
        
        /// <summary>
        /// 修改手机号码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="phoneNum">新的号码</param>
        /// <returns>是否修改成功</returns>
        public bool updatePhoneNum(string id, string phoneNum)
        {
            return dal.updatePhoneNum(id, phoneNum);
        }

        /// <summary>
        /// 查找手机号码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>用户手机号</returns>
        public Reproter selectPhoneNumber(string id)
        {
            return dal.selectPhoneNumber(id);
        }


        /// <summary>
        /// 通过id获取报修人名称
        /// </summary>
        /// <param name="id">报修人id</param>
        /// <returns></returns>
        public object GetReproterNamebyID(string id)
        {
            return dal.GetReproterNamebyID(id);
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="id">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Logining(string id, string pwd)
        {
            return dal.Logining(id, pwd);
        }
    }
}
