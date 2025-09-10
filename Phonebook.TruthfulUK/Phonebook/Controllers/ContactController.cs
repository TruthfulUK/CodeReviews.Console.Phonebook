using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers;
internal class ContactController
{
    public void InsertContact(Contact contact)
    {
        using (var db = new AppDbContext())
        {
            Console.WriteLine($"{contact.Name} being processed");
            db.Contacts.Add(contact);
            db.SaveChanges();
        }
    }
}
