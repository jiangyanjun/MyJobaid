using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MyJobaid.Common;

namespace MyJobaid.CodeGenerate.Core
{
    public class SQLDBInfo
    {
        private int _anthenticationtype = 0;
        private string _servername = "";
        private string _username = "";
        private string _userpwd = "";
        private string _database = "";
        private string MasterConnectionString
        {
            get;
            set;
        }

        private string DataBaseConnectionString
        {
            get;
            set;
        }

        public SQLDBInfo(int iAnthenticationType, string strServerName, string strUserName, string strUserPwd, string strDataBase)
        {
            this._anthenticationtype = iAnthenticationType;
            this._servername = strServerName;
            this._username = strUserName;
            this._userpwd = strUserPwd;
            this._database = strDataBase;
            if (this._anthenticationtype == 0)
            {
                MasterConnectionString = "data source=" + this._servername + ";initial catalog=" + this._database + ";integrated security=true";
            }
            else
            {
                MasterConnectionString = "server=" + this._servername + ";database =" + this._database + ";uid = " + this._username + "; pwd = " + this._userpwd + "";
            }
        }
       
        /// <summary>
        /// get database list from the connecting server 
        /// </summary>
        /// <returns></returns>
        public List<string> GetDatabaseList()
        {
            List<string> lstDatabase = new List<string>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(MasterConnectionString, CommandType.Text, "sp_databases", null))
            {
                while (reader.Read())
                {
                    lstDatabase.Add(reader["DATABASE_NAME"].ToString().Trim());
                }
            }
            return lstDatabase;
        }


        private string GetConnectionByDatabaseName(string strDatabaseName)
        {
            if (this._anthenticationtype == 0)
            {
                return "data source=" + this._servername + ";initial catalog=" + strDatabaseName + ";integrated security=true";
            }
            else
            {
                return  "server=" + this._servername + ";database =" + strDatabaseName + ";uid = " + this._username + "; pwd = " + this._userpwd + "";
            }
        }

        /// <summary>
        /// get tables from the specified database
        /// </summary>
        /// <param name="strDatabaseName"></param>
        /// <returns></returns>
        public List<string> GetDatabaseTables(string strDatabaseName)
        {
            List<string> lstTable = new List<string>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(GetConnectionByDatabaseName(strDatabaseName), CommandType.Text, "select * from sysobjects where  xtype='U'", null))
            {
                while (reader.Read())
                {
                    lstTable.Add(reader["name"].ToString().Trim());
                }
            }
            return lstTable;
        }

        /// <summary>
        /// get dataview from the specified database
        /// </summary>
        /// <param name="strDatabaseName"></param>
        /// <returns></returns>
        public List<string> GetDatabaseViews(string strDatabaseName)
        {
            List<string> lstView = new List<string>();
            using (SqlDataReader reader = SQLHelper.ExecuteReader(GetConnectionByDatabaseName(strDatabaseName), CommandType.Text, "select * from sysobjects where  xtype='V'", null))
            {
                while (reader.Read())
                {
                    lstView.Add(reader["name"].ToString().Trim());
                }
            }
            return lstView;
        }


        public List<ColumnInfo> GetTableColumns(string strDatabaseName, string strTableName)
        {
            List<ColumnInfo> lstColumn = new List<ColumnInfo>();
            //string strSql = "select";           
            //strSql += " c.name as cname,c.prec AS Prec,c.isnullable AS isnullable, ";
            //strSql += " [IsPk]=case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=c.id and name in ( ";
            //strSql += " SELECT name FROM sysindexes WHERE indid in(SELECT indid FROM sysindexkeys WHERE id = c.id AND colid=c.colid))) then '1' else '0' end, ";
            //strSql += " [defaultval]=isnull(e.text,''), ";
            //strSql += " t.name as tname   ";
            //strSql += " from syscolumns as c inner join sys.tables as ta on c.id=ta.object_id  ";
            //strSql += " inner join  (select name,system_type_id from sys.types where name<>'sysname') as t on c.xtype=t.system_type_id  ";
            //strSql += " left join syscomments e on c.cdefault=e.id where ta.name='" + strTableName + "'  ";
            using (SqlDataReader reader = SQLHelper.ExecuteReader(GetConnectionByDatabaseName(strDatabaseName), CommandType.Text, "sp_columns " + strTableName + "", null))
            {
                while (reader.Read())
                {
                    lstColumn.Add(new ColumnInfo() {
                        //ColumnName = reader["cname"].ToString().Trim(),
                        //ColumnType = reader["tname"].ToString().Trim(),
                        //IsPk = (reader["IsPk"].ToString().Trim() == "1")
                        ColumnName = reader["COLUMN_NAME"].ToString().Trim(),
                        ColumnType = reader["TYPE_NAME"].ToString().Trim(),
                        IsPk = (reader["ORDINAL_POSITION"].ToString().Trim() == "1"),
                        Precision = reader["PRECISION"].ToString().Trim(),
                        Length = reader["LENGTH"].ToString().Trim()
                    });
                }
            }
            return lstColumn;
        }

    }

    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
        public bool IsPk { get; set; }
        public string Precision { get; set; }
        public string Length { get; set; }
    }

}
