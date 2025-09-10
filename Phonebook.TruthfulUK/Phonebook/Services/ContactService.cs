using Phonebook.Controllers;
using Phonebook.Models;

namespace Phonebook.Services;
internal class ContactService
{
    private readonly ContactController _contacts;

    public ContactService()
    {
        _contacts = new ContactController();
    }

    public void AddContact()
    {
        Console.ReadKey();
    }
}
