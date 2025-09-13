using Phonebook.Models;

namespace Phonebook.Data;
internal static class Seeding
{
    public static void SeedContacts()
    {
        using (var db = new AppDbContext())
        {
            if (db.Contacts.Any()) return;
            
            List<Contact> data = new List<Contact>()
            {
                new Contact {
                    Name = "Andrew Donald",
                    PhoneNumber = "+1 1234 567 890",
                    Email = "a.donald@doesnotexist.dne",
                    CategoryId = 3 },
                new Contact {
                    Name = "Jane Doe",
                    PhoneNumber = "+44 1234 567 890",
                    Email = "jane-doe12@doesnotexist.dne",
                    CategoryId = 2 },
                new Contact {
                    Name = "Jane Smith",
                    PhoneNumber = "+20 1234 567 890",
                    Email = "jsmith1993@doesnotexist.dne",
                    CategoryId = 1 },
                new Contact
                {
                    Name = "Manager John",
                    PhoneNumber = "555 1234",
                    Email = "john@fakecompany.fake",
                    CategoryId = 4 },
                new Contact
                {
                    Name = "Aaron Swanson",
                    PhoneNumber = "+42 1234 567 890",
                    Email = "aa-ron.swanson@doesnotexist.dne",
                    CategoryId = 1 }
            };

            db.Contacts.AddRange(data);
            db.SaveChanges();
        }
    }
}
