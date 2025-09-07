using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Views;
internal class AppView
{
    private AppDbContext _db { get; set; }
    public AppView()
    {
        _db = new AppDbContext();
    }
    public void Run()
    {
        _db.Database.Migrate();

        while (true)
        {

            Console.WriteLine("Phonebook App");

            List<Contact> contacts = _db.Contacts.Include(c => c.Category).ToList();

            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Name} - {c.Category.Name}: {c.PhoneNumber} | {c.Email}");
            }

            Console.ReadLine();

            _db.Dispose();
            Environment.Exit(0);
        }
    }
}
