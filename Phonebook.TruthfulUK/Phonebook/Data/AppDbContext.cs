using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Phonebook.Models;

namespace Phonebook.Data;
internal class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\Projects;Database=Phonebook;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Name = "Unassigned", CategoryId = 1 },
            new Category { Name = "Family", CategoryId = 2 },
            new Category { Name = "Friends", CategoryId = 3 },
            new Category { Name = "Work", CategoryId = 4 }
        );

        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "John Smith", PhoneNumber = "0800 12 3456", CategoryId = 3 },
            new Contact { Id = 2, Name = "Jane Doe", PhoneNumber = "07 1234 567890", CategoryId = 2  },
            new Contact { Id = 3,  Name = "Jane Smith", PhoneNumber = "555 123 4567", CategoryId = 1 }
        );
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

}
