using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RepairsClient.Dal
{
    class SqlHelper
    {/// <summary>
        /// 连接字符串
        /// </summary>
        private static readonly string connectStr = ConfigurationManager.ConnectionStrings["strConnect"].ConnectionString;


        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">将要执行的sql语句</param>
        /// <param name="sqlPar">语句中的参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sqlStr, params  SqlParameter[] sqlPar)
        {
            //l连接数据库
            using (SqlConnection sqlCon = new SqlConnection(connectStr))
            {
                //数据库语句
                using (SqlCommand sqlCom = new SqlCommand(sqlStr, sqlCon))
                {
                    //判断数据库是否关闭
                    if (sqlCon.State == System.Data.ConnectionState.Closed)
                    {
                        //打开数据库
                        sqlCon.Open();
                    }
                    //判断参数是否为空
                    if (sqlPar != null)
                    {
                        //添加参数到sql语句中
                        sqlCom.Parameters.AddRange(sqlPar);

                    }
                    //返回受影响的行数
                    return sqlCom.ExecuteNonQuery();


                }//using command
            }//using connection


        }


        /// <summary>
        /// 返回查询结果第一行的第一列 忽略其他行其他列
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="sqlPar">sql语句中的参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlStr, params SqlParameter[] sqlPar)
        {
            //连接数据库
            using (SqlConnection sqlCon = new SqlConnection(connectStr))
            {
                using (SqlCommand sqlCom = new SqlCommand(sqlStr, sqlCon))
                {
                    //判断数据库是否打开
                    if (sqlCon.State == System.Data.ConnectionState.Closed)
                    {
                        //打开数据库
                        sqlCon.Open();
                    }
                    //判断参数
                    if (sqlPar != null)
                    {
                        //加入参数
                        sqlCom.Parameters.AddRange(sqlPar);
                    }
                    //返回查询结果的第一行的第一列
                    return sqlCom.ExecuteScalar();


                }//using command
            }//using connnect

        }


        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="sqlPar">语句中的参数</param>
        /// <returns>返回读取到的数据</returns>
        public static SqlDataReader ExecuteReader(string sqlStr, params SqlParameter[] sqlPar)
        {
            //连接数据库
            SqlConnection sqlCon = new SqlConnection(connectStr);
            using (SqlCommand sqlCom = new SqlCommand(sqlStr, sqlCon))
            {
                //添加参数
                if (sqlPar != null)
                {
                    sqlCom.Parameters.AddRange(sqlPar);
                }
                try
                {
                    //打开数据库
                    sqlCon.Open();
                    //返回读取到的数据 并关闭数据库
                    return sqlCom.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    //关闭数据库
                    sqlCon.Close();
                    //释放数据库
                    sqlCon.Dispose();
                    //抛异常
                    throw ex;
                }
            }//using sqlCom

        }


        /// <summary>
        /// 查询数据 放在一个表格中
        /// </summary>
        /// <param name="sqlStr">sql语句</param>
        /// <param name="sqlPar">语句中的参数</param>
        /// <returns>一个表格</returns>
        public static DataTable ExecuteTable(string sqlStr, params SqlParameter[] sqlPar)
        {
            DataTable tab = new DataTable();
            using (SqlDataAdapter sqltab = new SqlDataAdapter(sqlStr, connectStr))
            {
                //添加参数
                if (sqlPar != null)
                {
                    sqltab.SelectCommand.Parameters.AddRange(sqlPar);
                }
                sqltab.Fill(tab);
            }//using sqldatatable
            //返回表格
            return tab;
        }

    }
}
