using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers;
internal class CategoryController
{
    internal void InsertCategory(string name)
    {
        Category category = new Category { Name = name };

        using (var db = new AppDbContext())
        {
            db.Categories.Add(category); 
            db.SaveChanges();
        }
    }

    internal void UpdateCategory(int id, string newName)
    {
        using (var db = new AppDbContext())
        {
            db.Categories
                .Where(c => c.CategoryId == id)
                .ExecuteUpdate(c => c.SetProperty(c => c.Name, newName));
            db.SaveChanges();
        }
    }

    internal void DeleteCategory(int id)
    {
        using (var db = new AppDbContext())
        {
            using (var tx = db.Database.BeginTransaction())
            {
                db.Contacts
                    .Where(c => c.CategoryId == id)
                    .ExecuteUpdate(s => s.SetProperty(c => c.CategoryId, 1));
                tx.Commit();
            }
            db.Categories.Where(c => c.CategoryId == id).ExecuteDelete();
            db.SaveChanges();
        }
    }


    internal List<Category> SelectAllCategories()
    {
        using (var db = new AppDbContext())
        {
            return db.Categories.ToList();
        }
    }
}
