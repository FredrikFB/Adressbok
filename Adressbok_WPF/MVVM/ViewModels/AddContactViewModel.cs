using Adressbok_WPF.MVVM.Models;
using Adressbok_WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Adressbok_WPF.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title = "Add Contact";

        [ObservableProperty]
        private ContactModel contact= new ContactModel();

        [RelayCommand]
        public void Add()
        {
            ContactServices.Add(Contact);
            Contact = null!;

        }

    }
}
