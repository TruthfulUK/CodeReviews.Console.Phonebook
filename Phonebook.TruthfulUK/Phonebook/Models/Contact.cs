namespace Phonebook.Models;
internal class Contact
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int CategoryId { get; set; } = 1;
    public Category Category { get; set; }
}
