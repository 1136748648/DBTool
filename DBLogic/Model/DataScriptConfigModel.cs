namespace DBLogic.Model
{
    public class DataScriptConfigModel : FileBaseModel<DataScriptConfigModel>
    {
        /// <summary>
        /// 是否排除自增列
        /// </summary>
        public bool IsPcZzl { get; set; } = true;
        /// <summary>
        /// 是否表名=文件名
        /// </summary>
        public bool IsTName { get; set; } = false;
    }
}
