using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class FileService
    {
        public string FilePath { get; set; } = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

        public void Save( string content)
        {
            using var sw = new StreamWriter(FilePath);
            sw.Write(content);
        }
        public string Read() 
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                return sr.ReadToEnd();
            }
            catch { return null!; }
        }
    }
}
