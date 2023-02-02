using ConsoleApp.Models;
using ConsoleApp.Services;
using Newtonsoft.Json;

namespace ConsoleApp.Tests
{
    public class FileService_Test
    {
        FileService fileService;
        String content;

        public FileService_Test()
        {
            fileService= new FileService();
            fileService.FilePath= $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contentTest.json";
            content = JsonConvert.SerializeObject(new {FirsName="Fredrik", LastName="Blomqvist"});
        }


        [Fact]
        public void Should_Create_a_File_With_Json()
        {
            fileService.Save(content);
            string result = fileService.Read();

            Assert.True(File.Exists(fileService.FilePath));
            Assert.Equal(result, content);
        }
    }
}