using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers;
internal class ContactController
{
    internal void InsertContact(Contact contact)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }
    }

    internal void DeleteContact(int id)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts.Where(c => c.Id == id).ExecuteDelete();
        }
    }

    internal void UpdateContactName(int id, string newName)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.Name, newName));
            db.SaveChanges();
        }
    }

    internal void UpdatePhoneNumber(int id, string newNumber)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.PhoneNumber, newNumber));
            db.SaveChanges();
        }
    }

    internal void UpdateEmail(int id, string newEmail)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.Email, newEmail));
            db.SaveChanges();
        }
    }

    internal void UpdateCategory(int id, int categoryId)
    {
        using (var db = new AppDbContext())
        {
            db.Contacts
                .Where(c => c.Id == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.CategoryId, categoryId));
            db.SaveChanges();
        }
    }

    internal List<Contact> SelectAllContacts()
    {
        using (var db = new AppDbContext())
        {
            return db.Contacts.Include(c => c.Category).ToList();
        }
    }

    internal Contact SelectContactById(int id)
    {
        using (var db = new AppDbContext())
        {
            return db.Contacts.Find(id) ?? new Contact();
        }
    }
}
