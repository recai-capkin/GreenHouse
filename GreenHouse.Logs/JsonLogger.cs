using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouse.Logs
{
    public class JsonLogger<T> : ILogger<T> where T : class
    {
        private readonly string _fileName;
        public JsonLogger(string filename)
        {
            _fileName = filename;
        }
        string path="E:\\";
        public void Log(T message)
        {
            string strJson = JsonConvert.SerializeObject(message);
            string fullPath = Path.Combine(path, _fileName);
            File.WriteAllText(fullPath, strJson);
        }
    }
}
