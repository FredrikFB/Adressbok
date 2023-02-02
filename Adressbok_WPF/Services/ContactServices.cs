using Adressbok_WPF.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace Adressbok_WPF.Services
{
    public static class ContactServices
    {
        private static ObservableCollection<ContactModel> contacts;
        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");

        static ContactServices()
        {
            try
            {
                //using var sr = new StreamReader($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");
                //contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(fileService.Read())!;
            }
            catch { contacts = new ObservableCollection<ContactModel>(); }
        }

        public static void Add(ContactModel model) 
        {
           if(model !=null)
            {
                contacts.Add(model);
                fileService.Save(JsonConvert.SerializeObject(contacts));
            }
            else  MessageBox.Show("Fyll i fälten.");
            
 
        }
        public static void Remove(ContactModel model) 
        {
            if (model != null)
            {
                var res = MessageBox.Show("Vill du verkligen ta bort denna kontakten?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    contacts.Remove(model);
                    fileService.Save(JsonConvert.SerializeObject(contacts));
                }
                else MessageBox.Show("Bortagning avbruten");

            }
            else MessageBox.Show("Välj en kontakt att ta bort");
 
        }
        public static void Update(ContactModel model) 
        {
            if (model != null) 
            {
                var contact = contacts.FirstOrDefault(x => x.Id == model.Id)!;

                contact.FirstName= model.FirstName;
                contact.LastName= model.LastName;
                contact.Email= model.Email;
                contact.PhoneNumber= model.PhoneNumber;
                contact.Adress= model.Adress;
                fileService.Save(JsonConvert.SerializeObject(contacts));
            }
            else  MessageBox.Show("Kontakten hittades inte"); 
        }

        public static ObservableCollection<ContactModel> Contacts()
        {
            return contacts; 
        }
    }
}
