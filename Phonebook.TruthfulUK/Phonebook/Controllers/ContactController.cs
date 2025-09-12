using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers;
internal class ContactController
{
    public void InsertContact(Contact contact)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }
    }

    public List<Contact> SelectAllContacts()
    {
        using (var db = new AppDbContext())
        {
            return db.Contacts.Include(c => c.Category).ToList();
        }
    }
}
