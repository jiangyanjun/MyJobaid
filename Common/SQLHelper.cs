using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace MyJobaid.Common
{
    public abstract class SQLHelper
    {
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }


        public static bool ExecuteNonQuery(string connectionString, string[] cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlTransaction sqlTrans = conn.BeginTransaction();
                for (int i = 0; i < cmdText.Length; i++)
                {
                    PrepareCommand(cmd, conn, null, CommandType.Text, cmdText[i], null);
                    cmd.Transaction = sqlTrans;
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        return false;
                    }
                }
                sqlTrans.Commit();
                conn.Close();
                return true;
            }
        }

        public static bool ExecuteNonQuery(string connectionString, string[] cmdText, bool[] isCheck)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlTransaction sqlTrans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < cmdText.Length; i++)
                    {
                        PrepareCommand(cmd, conn, null, CommandType.Text, cmdText[i], null);
                        cmd.Transaction = sqlTrans;
                        int execCount = cmd.ExecuteNonQuery();
                        if (isCheck[i])
                        {
                            if (execCount == 0)
                            {
                                sqlTrans.Rollback();
                                return false;
                            }
                        }
                    }
                    sqlTrans.Commit();
                }
                catch (Exception ex)
                {
                    sqlTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return true;
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Execute a SqlCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// 执行一个事务
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static bool ExecuteNonQuery(string connectionString, string[] cmdText, IList<SqlParameter[]> commandParameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < cmdText.Length; i++)
                    {
                        ExecuteNonQuery(trans, CommandType.Text, cmdText[i], commandParameters[i]);
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    trans.Rollback();
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        /// <summary>
        /// Execute a SqlCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                conn.Close();
                throw;
            }
        }

        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                adp.Fill(data);
                return data;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, int pageSize, int startPage, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet data = new DataSet();
                adp.Fill(data, pageSize * (startPage - 1), pageSize, "table");
                return data;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }


        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }


        public static void ExecuteScalar(string connectionString, CommandType cmdType, string[] cmdText, out string[] excResult)
        {
            SqlCommand cmd = new SqlCommand();
            int i = 0;
            excResult = new string[cmdText.Length];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                foreach (string sql in cmdText)
                {
                    PrepareCommand(cmd, connection, null, cmdType, sql, null);
                    if (cmd.ExecuteScalar() == null)
                    {
                        excResult[i] = string.Empty;
                    }
                    else
                    {
                        excResult[i] = cmd.ExecuteScalar().ToString();
                    }
                    i++;
                }
            }
        }






        /// <summary>
        /// Execute a SqlCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="conn">an existing database connection</param>
        /// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="cmdParms">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


        public static int GetMaxID(string connStr, string tableName)
        {
            string[] result = new string[2];
            string[] cmdTexts = new string[2];
            cmdTexts[0] = "update tb_Sys_Maker set maxid = maxid + 1 where tablename = '" + tableName.ToUpper() + "'";
            cmdTexts[1] = "select maxid from tb_Sys_Maker where tablename = '" + tableName.ToUpper() + "'";
            SQLHelper.ExecuteScalar(connStr, CommandType.Text, cmdTexts, out result);
            return int.Parse(result[1]);
        }

        /// <summary>
        /// 组合一个分页的SQL语句
        /// <para>默认主键字段排序</para>
        /// </summary>
        /// <param name="strTableName">表名称</param>
        /// <param name="strSelectFiled">查询字段</param>
        /// <param name="strKeyField">主键字段</param>
        /// <param name="isDesc">排序规则是否倒排序</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页数</param>
        /// <returns></returns>
        public static string BuildPagerSqlString(string strTableName, Collection<string> strSelectFiled, string strKeyField, bool isDesc, int pageIndex, int pageSize)
        {
            return BuildPagerSqlString(strTableName, strSelectFiled, strKeyField, string.Empty, isDesc, pageIndex, pageSize);
        }


        /// <summary>
        /// 组合一个分页的SQL语句
        /// <para>默认主键 DESC 排序</para>
        /// </summary>
        /// <param name="strTableName">表名称</param>
        /// <param name="strSelectFiled">查询字段</param>
        /// <param name="strKeyField">主键字段</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页数</param>
        /// <returns></returns>
        public static string BuildPagerSqlString(string strTableName, Collection<string> strSelectFiled, string strKeyField, int pageIndex, int pageSize)
        {
            return BuildPagerSqlString(strTableName, strSelectFiled, strKeyField, string.Empty, true, pageIndex, pageSize);
        }

        /// <summary>
        /// 组合一个分页的SQL语句
        /// </summary>
        /// <param name="strTableName">表名称</param>
        /// <param name="strSelectFiled">查询字段</param>
        /// <param name="strKeyField">主键字段</param>
        /// <param name="strOrderFiled">排序字段</param>
        /// <param name="isDesc">排序规则是否倒排序</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页数</param>
        /// <returns></returns>
        public static string BuildPagerSqlString(string strTableName, Collection<string> strSelectFiled, string strKeyField, string strOrderFiled, bool isDesc, int pageIndex, int pageSize)
        {
            string strSelect = string.Join(",", strSelectFiled);
            string orderReg = "DESC";
            if (!isDesc)
            {
                orderReg = "ASC";
            }
            string sql = " SELECT TOP " + pageSize + " " + strSelect + " ";
            sql += " FROM " + strTableName + " WHERE " + strKeyField + " NOT IN ";
            sql += " ( ";
            sql += " SELECT TOP " + (pageSize * (pageIndex - 1)) + " " + strKeyField + " FROM " + strTableName + " ";
            if (string.IsNullOrEmpty(strOrderFiled))
            {
                sql += " ORDER BY " + strKeyField + " " + orderReg + "";
            }
            else
            {
                sql += " ORDER BY " + strOrderFiled + " " + orderReg + "";
            }
            sql += " ) ";
            return sql;
        }


        public static SqlParameter[] BuildPagerParams(string strTableName, string strColumns, string strSort, int iPageIndex, int iPageSize, string strWhere)
        {
            return BuildPagerParams(strTableName, strColumns, strSort, iPageIndex, iPageSize, strWhere, string.Empty);
        }

        public static SqlParameter[] BuildPagerParams(string strTableName, string strSort, int iPageIndex, int iPageSize, string strWhere)
        {
            return BuildPagerParams(strTableName, string.Empty, strSort, iPageIndex, iPageSize, strWhere, string.Empty);
        }


        /// <summary>
        /// 创建分页参数列表
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="strColumns"></param>
        /// <param name="strSort"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="iPageSize"></param>
        /// <param name="strWhere"></param>
        /// <param name="strPrevCode"></param>
        /// <returns></returns>
        public static SqlParameter[] BuildPagerParams(string strTableName, string strColumns, string strSort, int iPageIndex, int iPageSize, string strWhere, string strPrevCode)
        {
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter("tablename", SqlDbType.NVarChar),
                    new SqlParameter("column", SqlDbType.NVarChar),
                    new SqlParameter("sort", SqlDbType.NVarChar),
                    new SqlParameter("pageIndex", SqlDbType.NVarChar),
                    new SqlParameter("pageCount", SqlDbType.NVarChar),
                    new SqlParameter("where", SqlDbType.NVarChar),
                    new SqlParameter("prevCode", SqlDbType.NVarChar)
                };
            ps[0].Value = strTableName;
            ps[1].Value = strColumns;
            ps[2].Value = strSort;
            ps[3].Value = iPageIndex;
            ps[4].Value = iPageSize;
            ps[5].Value = strWhere;
            ps[6].Value = strPrevCode;

            return ps;
        }



    }
}
