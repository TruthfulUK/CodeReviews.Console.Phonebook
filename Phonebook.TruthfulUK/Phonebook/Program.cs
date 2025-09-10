using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Views;

var db = new AppDbContext();
var app = new AppView();

using (db)
{
    db.Database.EnsureDeleted();
    db.Database.Migrate();
}

app.Run();