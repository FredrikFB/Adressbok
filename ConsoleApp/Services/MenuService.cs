using ConsoleApp.Models;
using Newtonsoft.Json;

namespace ConsoleApp.Services;

public class MenuService
{
    public List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService();

    public void Menu()
    {
        PopulateContactList();

        Console.Clear();
        Console.WriteLine("Välkommen till Adressboken");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        Console.Write("Välj ett av elternativen ovan:");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1":
                OptionOne();
                break;
            case "2":
                OptionTwo();
                break;
            case "3":
                OptionThree();
                break;
            case "4":
                OptionFour();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Inte ett alternativ");
                Console.ReadKey();
                break;
        }

    }
    private void OptionOne()
    {
        Contact contact = new Contact();

        Console.Clear();
        Console.WriteLine("Lägg till en kontact");

        Console.Write("Skriv in Förnamn: ");
        contact.FirstName = Console.ReadLine()?? "";
        Console.Write("Skriv in Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Skriv in E-postadress: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Skriv in Telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Skriv in Gata: ");
        contact.Adress = Console.ReadLine() ?? "";
        Console.Write("Skriv in Postnummer: ");
        contact.Postalcode = Console.ReadLine() ?? "";
        Console.Write("Skriv in Stad: ");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);
        file.Save( JsonConvert.SerializeObject(contacts));
        

        Console.Clear() ;
        Console.WriteLine("Kontakt skapad.");
        Console.ReadKey();
    }
    private void OptionTwo()
    {
        Console.Clear();
        Console.WriteLine("Lista av kontakter");
        foreach (Contact contact in contacts) 
        {
            Console.WriteLine($"Namn: {contact.DisplayName}  \nE-post: {contact.Email} \n");
        }
        Console.ReadKey() ;
    }
    private void OptionThree() 
    {
        Console.Clear();
        Console.WriteLine("Skriv in förnamn på personen:");
        var firstName= Console.ReadLine();

        if (firstName != null)
        {
            Contact result = contacts.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower())!;
            Console.WriteLine($"Förnamn: {result.FirstName} \nEfternamn: {result.LastName} \nE-post: {result.Email} \nTelefonnummer: {result.PhoneNumber} \nAdress: {result.DisplayAdress} \n");
            Console.ReadKey();
        }
    }
    private void OptionFour()
    {
        Console.Clear();
        Console.WriteLine("Skriv in förnamn på personen:");
        var firstName = Console.ReadLine() ??"";
        Contact result = contacts.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower())!;

        if(result == null) 
        {
            Console.WriteLine("Kontakten hittades inte");
            Console.ReadKey();

        }else
        {
            Console.WriteLine("Vill du verkligen ta bort denna kontakten? (Y/N)");
            Console.WriteLine($"Förnamn: {result.FirstName} \nEfternamn: {result.LastName} \nE-post: {result.Email} \nTelefonnummer: {result.PhoneNumber} \nAdress: {result.DisplayAdress} \n");
            string res = Console.ReadLine() ??"";
            
            if(res.ToLower() == "y")
            {
                //contacts.Remove(result);
                contacts.Remove((Contact)result);
                file.Save(JsonConvert.SerializeObject(contacts));
                Console.Clear();
                Console.WriteLine("kontakt borttagen");
                Console.ReadKey();
            }

        }
    }
    void PopulateContactList()
    { 
        try
        {
            var content = file.Read();
            if(!string.IsNullOrEmpty(content)) 
            {
                contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }
        }
        catch { }
    }
}
