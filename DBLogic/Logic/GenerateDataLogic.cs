using DBLogic.Model;
using DBLogic.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DBLogic.Logic
{
    public class GenerateDataLogic
    {
        public static void GenerateData(DataConfigModel model)
        {
            try
            {
                var data = DBInfo.GetData(model.Sql.ConvertString());
                if (data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
                {
                    var dataTable = data.Tables[0];
                    StringBuilder str = new StringBuilder();
                    str.AppendLine();
                    //主表数据
                    TableData(dataTable, model.ZTableName, model.ZTablePk, model.IsPcZzl, ref str);
                    //从表数据
                    if (model.CbInfo != null && model.CbInfo.Count > 0)
                    {
                        foreach (var item in model.CbInfo)
                        {
                            string tempStr = "'";
                            if (dataTable.Columns.Contains(item.ZBZD.ConvertString()))
                            {
                                foreach (DataRow dr in dataTable.Rows)
                                {
                                    tempStr += dr[item.ZBZD.ConvertString()].ConvertString() + "','";
                                }
                            }
                            tempStr = tempStr.TrimEnd('\'').TrimEnd(',');
                            string sql = $"SELECT * FROM {item.TableName.ConvertString()} WHERE {item.CBZD.ConvertString()} IN ({tempStr})";
                            var tempData = DBInfo.GetData(sql).Tables[0];
                            //从表数据
                            TableData(tempData, item.TableName, item.CBZD, model.IsPcZzl, ref str, IsAutoPk: true);
                        }
                    }
                    if (string.IsNullOrEmpty(str.ToString()))
                    {
                        new Exception("生成失败");
                    }
                    str.Insert(0, $"/******{model.Name.ConvertString()} {DateTime.Now.ToString("yyyy-MM-dd")} START ******/");
                    str.AppendLine($"/******{model.Name.ConvertString()} END******/");
                    //保存文件
                    FileUtil.SaveFile(model.Path, model.Name.ConvertString() + ".sql", str.ConvertString());
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        private static void TableData(DataTable dataTable, string tableName, string pkName, bool IsPcZzl, ref StringBuilder str, bool IsAutoPk = false)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) return;
            str.AppendLine($"---- {tableName.ConvertString()} START ----");
            if (!IsPcZzl)
            {
                str.AppendLine($"SET IDENTITY_INSERT [{tableName.ConvertString()}] ON");
                str.AppendLine("GO");
            }
            var tableInfo = DBInfo.GetTableInfo_DS(tableName.ConvertString());
            if (IsAutoPk && tableInfo.Tables[1].Rows.Count > 0)
            {
                var _pkName = string.Empty;
                foreach (DataRow item in tableInfo.Tables[1].Rows)
                {
                    _pkName += item["name"].ConvertString() + "+";
                }
                if (!string.IsNullOrEmpty(_pkName))
                {
                    pkName = _pkName.TrimEnd('+');
                }
            }
            List<string> list = new List<string>();
            foreach (DataRow dr in tableInfo.Tables[0].Rows)
            {
                if (IsPcZzl && dr["IsIdentity"].ConvertInt32() == 1)
                {
                    continue;
                }
                if (dataTable.Columns.Contains(dr["COLUMN_NAME"].ConvertString()))
                {
                    list.Add(dr["COLUMN_NAME"].ConvertString());
                }
            }
            var tempTable = dataTable.DefaultView.ToTable(true, list.ToArray());
            var ZTablePk = pkName.ConvertString().Split('+');
            foreach (DataRow item in tempTable.Rows)
            {
                string strPk = string.Empty;
                foreach (var s in ZTablePk)
                {
                    strPk += item[s].ConvertString();
                }
                str.AppendLine("--");
                str.AppendLine($"IF NOT EXISTS (select 1 from {tableName.ConvertString()} where {pkName.ConvertString()}='{strPk}')");
                str.AppendLine("BEGIN");
                str.AppendLine($"    INSERT INTO {tableName.ConvertString()}");
                str.AppendLine($"        ({string.Join(",", list)})");
                str.AppendLine("    VALUES");
                str.AppendLine($"        ('{string.Join("','", item.ItemArray)}')");
                str.AppendLine("END");
                str.AppendLine("GO");
            }
            if (!IsPcZzl)
            {
                str.AppendLine($@"SET IDENTITY_INSERT [{tableName.ConvertString()}] OFF");
                str.AppendLine("GO");
            }
            str.AppendLine($"---- {tableName.ConvertString()} END ----");
        }
    }
}
