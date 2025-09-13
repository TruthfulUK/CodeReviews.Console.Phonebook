using Microsoft.EntityFrameworkCore;
using Phonebook.Models;

namespace Phonebook.Data;
internal class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\Projects;Database=Phonebook;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Name = "Unassigned", CategoryId = 1 },
            new Category { Name = "Family", CategoryId = 2 },
            new Category { Name = "Friends", CategoryId = 3 },
            new Category { Name = "Work", CategoryId = 4 }
        );
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

}
