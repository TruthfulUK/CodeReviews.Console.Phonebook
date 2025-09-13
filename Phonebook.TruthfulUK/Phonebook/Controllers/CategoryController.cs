using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers;
internal class CategoryController
{
    public List<Category> SelectAllCategories()
    {
        using (var db = new AppDbContext())
        {
            return db.Categories.ToList();
        }
    }
}
