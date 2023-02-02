

using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests
{
    public class MenuService_Test
    {
        private MenuService menuService;
        Contact contact;

        public MenuService_Test()
        {
            menuService = new MenuService();
            contact = new Contact();
        }


        [Fact]
        public void SHoud_Add_Contact()
        {
            menuService.contacts.Add(contact);

            Assert.Single(menuService.contacts);
        }

        [Fact]
        public void Shud_Remove_Contact()
        {
            menuService.contacts.Add(contact);

            menuService.contacts.Remove(contact);

            Assert.Empty(menuService.contacts);
        }
    }
}
