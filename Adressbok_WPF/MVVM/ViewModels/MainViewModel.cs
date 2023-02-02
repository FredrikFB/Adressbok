using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_WPF.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject 
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void AddContact() => CurrentViewModel = new AddContactViewModel();

        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactsViewModel();

        [RelayCommand]
        private void GoToUpdate() => CurrentViewModel = new UpdateContactViewModel();


        public MainViewModel()
        {
            CurrentViewModel = new ContactsViewModel();
        }
    }
}
