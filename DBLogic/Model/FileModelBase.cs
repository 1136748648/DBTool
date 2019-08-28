using DBLogic.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DBLogic.Model
{
    public class FileModelBase<T> where T : class
    {
        private string _id_ = Guid.NewGuid().ToString();
        [JsonProperty]
        public string _Id_
        {
            get
            {
                return _id_;
            }
            set
            {
                _id_ = value;
            }
        }
        public static string ClassName
        {
            get
            {
                return typeof(T).Name;
            }
        }
        public static List<T> F_DBList
        {
            get
            {
                if (FileModelBase.F_DbDic.ContainsKey(ClassName))
                {
                    return FileModelBase.F_DbDic[ClassName].Select(i =>
                    {
                        if (i is JObject)
                            return ((JObject)i).ToObject<T>();
                        return (T)i;
                    }).ToList();
                }
                return new List<T>();
            }
        }
        public void AddOrUpdate()
        {
            if (!FileModelBase.F_DbDic.ContainsKey(ClassName))
            {
                FileModelBase.F_DbDic.Add(ClassName, new List<Object>());
            }
            Delete();
            FileModelBase.F_DbDic[ClassName].Add((T)this.MemberwiseClone());
        }
        public void Delete()
        {
            if (!FileModelBase.F_DbDic.ContainsKey(ClassName))
            {
                FileModelBase.F_DbDic.Add(ClassName, new List<Object>());
            }
            var item = FileModelBase.F_DbDic[ClassName].Select(i =>
            {
                T _i = null;
                if (i is JObject)
                    _i = ((JObject)i).ToObject<T>();
                else
                    _i = (T)i;
                var id_Obj = _i.GetType().GetProperty("_Id_");
                if (id_Obj != null && id_Obj.GetValue(_i).Equals(this._Id_))
                    return i;
                return null;
            }).FirstOrDefault();
            if (item != null)
            {
                FileModelBase.F_DbDic[ClassName].Remove(item);
            }
        }
    }
    public class FileModelBase
    {
        public static Dictionary<string, List<Object>> F_DbDic { get; set; } = new Dictionary<string, List<Object>>();
        public static string basePath { get; set; } = System.Environment.CurrentDirectory + "\\DBCache\\";
        public static void Load()
        {
            var jsonData = FileUtil.ReadFile(basePath, "dbTool.cache");
            if (!string.IsNullOrEmpty(jsonData))
            {
                //jsonData = HttpUtility.HtmlDecode(jsonData);
                F_DbDic = JsonConvert.DeserializeObject<Dictionary<string, List<Object>>>(jsonData);
            }
        }
        public static void Save()
        {
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            string jsonData = JsonConvert.SerializeObject(F_DbDic);
            //jsonData = HttpUtility.HtmlEncode(jsonData);
            FileUtil.SaveFile(basePath, "dbTool.cache", jsonData);
        }
    }
}
