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

namespace Adressbok_WPF.MVVM.ViewModels
{
    public partial class UpdateContactViewModel : ObservableObject 
    {
        [ObservableProperty]
        private string title = "Edit Contact";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts = ContactServices.Contacts();

        [ObservableProperty]
        private ContactModel editContact = null!;

        [RelayCommand]
        public void Update() 
        {
            ContactServices.Update(EditContact); 
            EditContact= null!;
        }
 

    }
}
