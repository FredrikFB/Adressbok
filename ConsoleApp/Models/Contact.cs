internal interface IContacts
{
    string FirstName { get; set; } 
    string LastName { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string Adress { get; set; }
}

namespace ConsoleApp.Models
{
    internal class Contact : IContacts
    {
        public Guid Id = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;
    }
}
