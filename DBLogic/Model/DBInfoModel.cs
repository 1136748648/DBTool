using DBLogic.Util;

namespace DBLogic.Model
{
    public class DBInfoModel : FileModelBase<DBInfoModel>
    {
        public string Ip { get; set; }
        public string User { get; set; }
        public string pwd { get; set; }
        public string def_DB { get; set; } = "master";
    }
}
