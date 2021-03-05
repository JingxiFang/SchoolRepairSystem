using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using RepairsClient.Model;
using System.Data;

namespace RepairsClient.Dal
{
    public class ReproterDal
    {
        /// <summary>
        /// 修改手机号码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="phoneNum">新的号码</param>
        /// <returns>是否修改成功</returns>
        public bool updatePhoneNum(string id, string phoneNum)
        {
            string strSql = "update Reproter set phonenum='" + phoneNum + "' where repid='" + id + "'";
            return SqlHelper.ExecuteNonQuery(strSql)>0;
 
        }

        /// <summary>
        /// 查找手机号码
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>用户手机号</returns>
        public Reproter selectPhoneNumber(string id)
        {
            string strSql="select phonenum,name,repid from Reproter where RepId='"+id+"'";
            DataTable dt= SqlHelper.ExecuteTable(strSql);
            Reproter rep = new Reproter();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    rep.Name = dt.Rows[0]["name"].ToString();
                    rep.PhoneNum = dt.Rows[0]["phonenum"].ToString();
                    rep.Id = dt.Rows[0]["repid"].ToString();
                }
            }
            return rep;
            
        }


        /// <summary>
        /// 通过id获取报修人名称
        /// </summary>
        /// <param name="id">报修人id</param>
        /// <returns></returns>
        public object GetReproterNamebyID(string id)
        {
            string strSql = "select name from Reproter where RepId='" + id + "'";
            return SqlHelper.ExecuteScalar(strSql);
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="id">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public bool Logining(string id, string pwd)
        {
            string strSql = "select count(*) from reproter where repid=@repid and idcard=@pwd";
            SqlParameter[] sp={
                              new SqlParameter("@repid",id),
                              new SqlParameter("@pwd",pwd)
                              };
            return Convert.ToInt32(  SqlHelper.ExecuteScalar(strSql, sp))>0;
        }
    }
}
