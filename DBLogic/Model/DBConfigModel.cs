using System.Collections.Generic;

namespace DBLogic.Model
{
    public class DBConfigModel : FileBaseModel<List<DBConfigModel>>
    {
        public string Ip { get; set; }
        public string User { get; set; }
        public string pwd { get; set; }
        public string def_DB { get; set; } = "master";
    }
}
