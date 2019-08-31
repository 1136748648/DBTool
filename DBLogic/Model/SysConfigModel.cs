namespace DBLogic.Model
{
    public class SysConfigModel : FileBaseModel<SysConfigModel>
    {
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string Path { get; set; }
    }
}
