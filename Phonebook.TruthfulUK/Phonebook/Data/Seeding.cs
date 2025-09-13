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
                    PhoneNumber = "0800 12 3456",
                    Email = "a.donald@doesnotexist.dne",
                    CategoryId = 3 },
                new Contact {
                    Name = "Jane Doe",
                    PhoneNumber = "07 1234 567890",
                    Email = "jane-doe12@doesnotexist.dne",
                    CategoryId = 2 },
                new Contact {
                    Name = "Jane Smith",
                    PhoneNumber = "555 123 4567",
                    Email = "jsmith1993@doesnotexist.dne",
                    CategoryId = 1 },
                new Contact
                {
                    Name = "Manager John",
                    PhoneNumber = "111 456 789",
                    Email = "john@fakecompany.fake",
                    CategoryId = 4 },
                new Contact
                {
                    Name = "Aaron Swanson",
                    PhoneNumber = "+42 232 345 0933",
                    Email = "aa-ron.swanson@doesnotexist.dne",
                    CategoryId = 1 }
            };

            db.Contacts.AddRange(data);
            db.SaveChanges();
        }
    }
}
