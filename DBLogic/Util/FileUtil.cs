using System.IO;
using System.Text;
using System.Web;

namespace DBLogic.Util
{
    public class FileUtil
    {
        public static void SaveFile(string path, string fileName, string str)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter fs = new StreamWriter(Path.Combine(path, fileName), false, Encoding.UTF8))
            {
                fs.Write(str);
            }
        }
        public static string ReadFile(string path, string fileName)
        {
            return ReadFile(Path.Combine(path, fileName));
        }
        public static string ReadFile(string path)
        {
            string jsonData = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader fs = new StreamReader(path, Encoding.UTF8))
                {
                    jsonData = fs.ReadToEnd();
                }
            }
            return jsonData;
        }
    }
}
