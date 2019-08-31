using DBLogic.Model;
using DBLogic.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace DBLogic.Logic
{
    public class TableScriptLogic
    {
        private static string GetPath()
        {
            return Path.Combine(SysConfigModel.F_DBInfo.Path, "表脚本");
        }
        public static void CreateTableSql(List<string> nameTable, bool isToUpper)
        {
            string path = GetPath();
            if (nameTable != null)
            {
                foreach (var item in nameTable)
                {
                    CreateTableSql(item, path, isToUpper);
                }
            }
        }
        public static void CreateTableSql(string nameTable, string path = "", bool isToUpper = true)
        {
            try
            {
                var dt = DBInfo.GetTableInfo_DT(nameTable);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string str = string.Empty;
                    StringBuilder str1 = new StringBuilder();
                    StringBuilder str2 = new StringBuilder();
                    string PK = string.Empty;
                    str1.AppendLine($"/****** 对象:  Table [dbo].[{nameTable}]    脚本日期: {DateTime.Now.ToString("yyyy-MM-dd")} ******/");
                    str1.AppendLine("SET ANSI_NULLS ON");
                    str1.AppendLine("GO");
                    str1.AppendLine("SET QUOTED_IDENTIFIER ON");
                    str1.AppendLine("GO");
                    str1.AppendLine("SET ANSI_PADDING ON");
                    str1.AppendLine("GO");
                    str1.AppendLine($"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{nameTable}]') AND type in (N'U'))");
                    str1.AppendLine("BEGIN");
                    str1.AppendLine($"CREATE TABLE [dbo].[{nameTable}](");
                    foreach (DataRow dr in dt.Rows)
                    {
                        string name = isToUpper ? dr["COLUMN_NAME"].ConvertString().ToUpper() : dr["COLUMN_NAME"].ConvertString();
                        string identity = dr["IsIdentity"].ConvertBoolean() ? "identity(1, 1)" : "";
                        string isNull = dr["IS_NULLABLE"].ConvertBoolean() ? "" : "not null";
                        string type = dr["DATA_TYPE"].ConvertString();
                        string _default = dr["COLUMN_DEFAULT"].ConvertString();
                        _default = string.IsNullOrEmpty(_default) ? "" : $"default '{_default}'";
                        str1.AppendLine($"	{name} {type} {identity} {isNull} {_default},");
                        if (dr["IsKey"].ConvertBoolean())
                        {
                            PK += name + ",";
                        }
                        else
                        {
                            str2.AppendLine($"IF NOT EXISTS (SELECT * FROM dbo.syscolumns WHERE id = object_id('[dbo].[{nameTable}]')");
                            str2.AppendLine($"	AND OBJECTPROPERTY(id, N'IsUserTable') = 1 AND name = '{name}')");
                            str2.AppendLine($"        ALTER TABLE [dbo].[{nameTable}] ADD {name} {type} {identity} {isNull} {_default}");
                            str2.AppendLine("GO");
                        }
                    }
                    if (!string.IsNullOrEmpty(PK))
                    {
                        str1.AppendLine($"constraint PK_{nameTable} primary key ({PK.TrimEnd(',')}),");
                    }
                    str1.AppendLine(")");
                    str1.AppendLine("END");
                    str1.AppendLine("GO");
                    str1.AppendLine("SET ANSI_PADDING OFF");
                    str1.AppendLine("GO");
                    str = str1.ToString() + str2.ToString();
                    FileUtil.SaveFile(path, nameTable + ".sql", str);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
