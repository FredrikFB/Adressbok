using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok_WPF.MVVM.Models
{
    public class ContactModel
    {
        public Guid Id = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string City { get; set; } = null!;
        public string Postalcode { get; set; } = null!;
        public string DisplayName => $"{FirstName} {LastName}";
        public string DisplayAdress => $"{Adress}, {Postalcode} {City}";
    }
}
