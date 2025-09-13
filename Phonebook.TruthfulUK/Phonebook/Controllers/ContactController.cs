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

    public void DeleteContact(int id)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts.Where(c => c.Id == id).ExecuteDelete();
        }
    }

    public void UpdateContactName(int id, string newName)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.Name, newName));
            db.SaveChanges();
        }
    }

    public void UpdatePhoneNumber(int id, string newNumber)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.PhoneNumber, newNumber));
            db.SaveChanges();
        }
    }

    public void UpdateEmail(int id, string newEmail)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.Email, newEmail));
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

    public Contact SelectContactById(int id)
    {
        using (var db = new AppDbContext())
        {
            return db.Contacts.Find(id) ?? new Contact();
        }
    }
}
