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
        public static DataSet GetTableInfo(string tableName)
        {
            string sql = @"SELECT  c.TABLE_SCHEMA ,
                        c.TABLE_NAME ,
                        c.COLUMN_NAME ,
                        c.DATA_TYPE ,
                        c.CHARACTER_MAXIMUM_LENGTH ,
                        c.COLUMN_DEFAULT ,
                        c.IS_NULLABLE ,
                        c.NUMERIC_PRECISION ,
                        c.NUMERIC_SCALE
                FROM    [INFORMATION_SCHEMA].[COLUMNS] c
                WHERE   TABLE_NAME = @tableName;
                SELECT name
                FROM   syscolumns
                WHERE  id = OBJECT_ID(@tableName) 
                AND colid IN (SELECT keyno FROM   sysindexkeys WHERE  id = OBJECT_ID(@tableName));";
            return SQLHelper.ExecuteDataSet(sql, new SqlParameter("@tableName", tableName));
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
