using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace WebAppCore.DbExtensions
{
    /// <summary>
    /// add by helm
    /// sample:
    /// var params = "小明"
    /// var sql = "select * from demo where name='{params}'"
    /// var tempDate = SqlQuery<ResultModel>(_context, Sql).ToList();
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <typeparam name="TResult">返回的对象</typeparam>
        /// <param name="context">上下文</param>
        /// <param name="sql">原生SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public static List<TResult> SqlQuery<TResult>(DbContext context, string sql, params object[] parameters) where TResult : class, new()
        {
            List<TResult> list = new List<TResult>();
            var conn = context.Database.GetDbConnection();
            using (var comm = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    comm.CommandText = sql;
                    if (parameters != null)
                        comm.Parameters.AddRange(parameters);
                    //CommandBehavior.CloseConnection当SqlDataReader释放的时候，顺便把SqlConnection对象也释放掉
                    var dr = comm.ExecuteReader(CommandBehavior.Default);

                    while (dr.Read())
                    {
                        TResult t = new TResult();
                        for (var i = 0; i < dr.FieldCount; i++)
                        {

                            //类型mapper,有同名的字段或属性赋值否则丢弃
                            var columnName = dr.GetName(i);
                            var colDataType = dr.GetFieldType(i);
                            var val = dr.GetFieldValue<object>(i);

                            var field = t.GetType().GetField(columnName);
                            field?.SetValue(t, val);

                            var property = t.GetType().GetProperty(columnName);
                            property?.SetValue(t, val);
                        }
                        list.Add(t);
                    }
                    dr.Dispose();//调用Dispose之后,该连接会关闭并被销毁,打上回收标记
                }
                catch (Exception ex)
                {
                    //这里对ex.Message 写日志吧
                    throw ex;
                }
                finally
                {
                    //Dispose 适合只在方法中调用一次 SqlConnection 对象，而 Close 更适合 SqlConnection 在关闭后可能需要再次打开的情况
                    //if (conn != null && conn.State != ConnectionState.Closed)
                    //{
                    //    //conn.Close();
                    //}
                }
            }
            return list;
        }

    }
}
