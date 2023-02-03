using Adressbok_WPF.MVVM.Models;
using Adressbok_WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Adressbok_WPF.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {

        [ObservableProperty]
        private string title = "Contacts";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactServices.Contacts();

        [ObservableProperty]
        private ContactModel selectContact = null!;

        [RelayCommand]
        public void Remove() 
        {
            var res = MessageBox.Show("Vill du verkligen ta bort denna kontakten?","Confirmation", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                ContactServices.Remove(SelectContact);
            }
            else MessageBox.Show("Bortagning avbruten");
        }

        
    }
}
