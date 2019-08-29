using System.Collections.Generic;

namespace DBLogic.Model
{
    public class DataConfigModel : FileModelBase<List<DataConfigModel>>
    {
        private string _Name = string.Empty;
        public string Name { get { if (string.IsNullOrEmpty(_Name)) return ZTableName; else return _Name; } set { _Name = value; } }
        public string Path { get; set; }
        public string ZTableName { get; set; }
        public string ZTablePk { get; set; }
        public string Sql { get; set; }
        /// <summary>
        /// 是否排除自增列
        /// </summary>
        public bool IsPcZzl { get; set; } = true;
        public List<DataConfig_CbModel> CbInfo { get; set; }
    }
    public class DataConfig_CbModel
    {
        public string TableName { get; set; }
        public string ZBZD { get; set; }
        public string CBZD { get; set; }
    }
}
