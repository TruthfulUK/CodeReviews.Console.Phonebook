namespace Phonebook.Models;
internal class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public IList<Contact> Contacts { get; set; }
    public Category()
    {
        Contacts = new List<Contact>();
    }
}
