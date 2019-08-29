using System.Collections.Generic;

namespace DBLogic.Model
{
    public class DataConfigModel : FileModelBase<List<DataConfigModel>>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string ZTableName { get; set; }
        public string ZTablePk { get; set; }
        public string Sql { get; set; }
        public List<DataConfig_CbModel> CbInfo { get; set; }
    }
    public class DataConfig_CbModel
    {
        public string TableName { get; set; }
        public string ZBZD { get; set; }
        public string CBZD { get; set; }
    }
}
