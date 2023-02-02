using Adressbok_WPF.MVVM.Models;
using Adressbok_WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Adressbok_WPF.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        public static implicit operator ObservableObject(ContactsView v)
        {
            throw new NotImplementedException();
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext;
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactModel)button.DataContext; 

            ContactServices.Remove(contact); 
        }

    }
}
