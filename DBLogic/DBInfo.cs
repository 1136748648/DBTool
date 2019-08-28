using DBHelper;
using DBLogic.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DBLogic
{
    public class DBInfo
    {
        private static string ConnectionStringTemp = "Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
        public static void SetConnectionString(DBInfoModel model)
        {
            string str = string.Format(ConnectionStringTemp, model.Ip, model.def_DB, model.User, model.pwd);
            SQLHelper.Instance.ConnectionString = str;
        }
        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>表一字段信息，表二主键</returns>
        public static DataSet GetTableInfo_DS(string tableName)
        {
            string sql = $@"SELECT  c.TABLE_SCHEMA ,
                        c.TABLE_NAME ,
                        c.COLUMN_NAME ,
                        c.DATA_TYPE ,
                        c.CHARACTER_MAXIMUM_LENGTH ,
                        c.COLUMN_DEFAULT ,
                        c.IS_NULLABLE ,
                        c.NUMERIC_PRECISION ,
                        c.NUMERIC_SCALE,
                        COLUMNPROPERTY(OBJECT_ID('{tableName}'), COLUMN_NAME, 'IsIdentity') as IsIdentity
                FROM    [INFORMATION_SCHEMA].[COLUMNS] c
                WHERE   TABLE_NAME = '{tableName}';
                SELECT name
                FROM   syscolumns
                WHERE  id = OBJECT_ID('{tableName}') 
                AND colid IN (SELECT keyno FROM   sysindexkeys WHERE  id = OBJECT_ID('{tableName}'));";
            return SQLHelper.ExecuteDataSet(sql);
        }
        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>表一字段信息，表二主键</returns>
        public static DataTable GetTableInfo_DT(string tableName)
        {
            DataSet ds = GetTableInfo_DS(tableName);
            DataTable dataTable = new DataTable();
            dataTable.TableName = tableName;
            dataTable.Columns.Add("COLUMN_NAME", typeof(string));
            dataTable.Columns.Add("DATA_TYPE", typeof(string));
            dataTable.Columns.Add("IS_NULLABLE", typeof(bool));
            dataTable.Columns.Add("COLUMN_DEFAULT", typeof(string));
            dataTable.Columns.Add("IsKey", typeof(bool));
            dataTable.Columns.Add("IsIdentity", typeof(bool));
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string DATA_TYPE = item["DATA_TYPE"].ToString().Trim();
                    string CHARACTER_MAXIMUM_LENGTH = item["CHARACTER_MAXIMUM_LENGTH"].ToString().Trim();
                    string NUMERIC_PRECISION = item["NUMERIC_PRECISION"].ToString().Trim();
                    string NUMERIC_SCALE = item["NUMERIC_SCALE"].ToString().Trim();
                    string COLUMN_DEFAULT = item["COLUMN_DEFAULT"].ToString().Trim();
                    if (!string.IsNullOrEmpty(CHARACTER_MAXIMUM_LENGTH))
                    {
                        DATA_TYPE = $"{DATA_TYPE}({CHARACTER_MAXIMUM_LENGTH})";
                    }
                    else if (DATA_TYPE.ToLower().Equals("numeric"))
                    {
                        DATA_TYPE = $"{DATA_TYPE}({NUMERIC_PRECISION},{NUMERIC_SCALE})";
                    }
                    COLUMN_DEFAULT = COLUMN_DEFAULT.Replace("(", "").Replace(")", "");
                    bool isKey = false;
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow kdr in ds.Tables[1].Rows)
                        {
                            if (kdr["name"].ToString().Trim().Equals(item["COLUMN_NAME"].ToString()))
                            {
                                isKey = true;
                            }
                        }
                    }
                    bool IsIdentity = item["IsIdentity"].ToString().Trim().Equals("1");
                    bool IS_NULLABLE = item["IS_NULLABLE"].ToString().Trim().ToLower().Equals("yes");
                    dataTable.Rows.Add(item["COLUMN_NAME"].ToString(), DATA_TYPE, IS_NULLABLE, COLUMN_DEFAULT, isKey, IsIdentity);
                }
            }
            return dataTable;
        }
        /// <summary>
        /// 获取数据库的所有表
        /// </summary>
        public static DataTable GetTablesInfo(string dbName)
        {
            string sql = $@"SELECT   name
                            FROM     [{dbName}]..sysobjects
                            WHERE    xtype = 'U'
                            ORDER BY name;";
            return SQLHelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDBsInfo()
        {
            string sql = @"SELECT name
                        FROM   master..sysdatabases
                        WHERE  name NOT IN ( 'master', 'model', 'msdb', 'tempdb', 'northwind', 'pubs' );";
            return SQLHelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取sql执行结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetData(string sql)
        {
            return SQLHelper.ExecuteDataSet(sql);
        }
        public static SQLHelper SQLHelper
        {
            get
            {
                if (string.IsNullOrEmpty(SQLHelper.Instance.ConnectionString))
                {
                    throw new Exception("数据连接未配置");
                }
                return SQLHelper.Instance;
            }
        }
    }
}
