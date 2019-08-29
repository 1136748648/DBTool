using DBLogic.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace DBLogic.Model
{
    public class FileModelBase<T> where T : new()
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
        private static bool IsList
        {
            get
            {
                return typeof(T).Name == typeof(List<>).Name;
            }
        }
        private static Type ModelType
        {
            get
            {
                if (IsList)
                {
                    return typeof(T).GenericTypeArguments[0];
                }
                return typeof(T);
            }
        }
        public static string ClassName
        {
            get
            {
                return ModelType.Name;
            }
        }
        public static T F_DBInfo
        {
            get
            {
                if (FileModelBase.F_DbDic.ContainsKey(ClassName))
                {
                    var obj = FileModelBase.F_DbDic[ClassName];
                    if (obj is JContainer)
                    {
                        return ((JContainer)FileModelBase.F_DbDic[ClassName]).ToObject<T>();
                    }
                    else
                    {
                        return (T)obj;
                    }
                }
                return new T();
            }
        }
        public void AddOrUpdate()
        {
            if (!FileModelBase.F_DbDic.ContainsKey(ClassName))
            {
                FileModelBase.F_DbDic.Add(ClassName, new JArray());
            }
            if (IsList)
            {
                Delete();
                ((JArray)FileModelBase.F_DbDic[ClassName]).Add(JObject.FromObject(this));
            }
            else
            {
                FileModelBase.F_DbDic[ClassName] = this;
            }
        }
        public void Delete()
        {
            if (IsList)
            {
                if (!FileModelBase.F_DbDic.ContainsKey(ClassName))
                {
                    FileModelBase.F_DbDic.Add(ClassName, new JArray());
                }
                JArray jArray = new JArray();
                foreach (var i in (JArray)FileModelBase.F_DbDic[ClassName])
                {

                    if (!i["_Id_"].ConvertString().Equals(this._Id_))
                    {
                        jArray.Add(i);
                    }
                }
                FileModelBase.F_DbDic[ClassName] = jArray;
            }
        }
    }
    public class FileModelBase
    {
        public static Dictionary<string, Object> F_DbDic { get; set; } = new Dictionary<string, Object>();
        public static string basePath { get; set; } = System.Environment.CurrentDirectory + "\\DBCache\\";
        public static void Load()
        {
            var jsonData = FileUtil.ReadFile(basePath, "dbTool.cache");
            if (!string.IsNullOrEmpty(jsonData))
            {
                //jsonData = HttpUtility.HtmlDecode(jsonData);
                F_DbDic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsonData);
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
