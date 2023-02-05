using Adressbok_WPF.MVVM.Models;
using Adressbok_WPF.MVVM.ViewModels;
using FluentAssertions;
using System.Collections.ObjectModel;

namespace Adressbok.Test
{
    public class ContactsViewModel_Test
    {
        private ContactsViewModel viewModel;

        public ContactsViewModel_Test()
        {
            viewModel= new ContactsViewModel();
        }

        [Fact]
        public void Test1()
        {
            ContactModel contact= new ContactModel();
            viewModel.Contacts.Add(contact);


            viewModel.Contacts.Should().BeOfType<ObservableCollection<ContactModel>>();
            viewModel.Contacts.Should().Contain(contact);
        }
    }
}