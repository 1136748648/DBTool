namespace DBLogic.Model
{
    public class TableConfigModel : FileBaseModel<TableConfigModel>
    {
        /// <summary>
        /// 列名称是否统一大写
        /// </summary>
        public bool IsToUpper { get; set; } = true;
    }
}
