using ConsoleApp.Models;


namespace ConsoleApp.Services;

internal class MenuService
{
    private List<IContacts> contacts = new List<IContacts>();

    public void Menu()
    {
        

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
        IContacts contact = new Contact();

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
        Console.Write("Skriv in Adress: ");
        contact.Adress = Console.ReadLine() ?? "";

        contacts.Add(contact);
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
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
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
            IContacts result = contacts.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower())!;
            Console.WriteLine($"{result.FirstName} {result.LastName}");
            Console.ReadKey();
        }
    }
    private void OptionFour()
    {
        Console.Clear();
        Console.WriteLine("Skriv in förnamn på personen:");
        var firstName = Console.ReadLine() ??"";
        IContacts result = contacts.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower())!;

        if(result!= null) 
        {
            contacts.Remove(result);
            Console.Clear();
            Console.WriteLine("kontakt borttagen");
            Console.ReadKey();
        }
    }
}
