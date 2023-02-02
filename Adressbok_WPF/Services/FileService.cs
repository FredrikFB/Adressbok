

using System.IO;

namespace Adressbok_WPF.Services
{
    public class FileService
    {
        private string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public string Read() 
        {
            
            if(File.Exists(_filePath)) 
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
            return string.Empty;
        }
        public void Save(string content) 
        {
            using var sw = new StreamWriter(_filePath);
            sw.Write(content);
        }
    }
}
