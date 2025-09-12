using Phonebook.Controllers;
using Phonebook.Helpers;
using Phonebook.Models;
using Phonebook.Enums;
using Spectre.Console;

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
        Display.DisplayHeader("Add a New Contact");

        var c = new Contact();

        c.Name = Validation.ValidateInput(
            "Enter a Contact Name: ", InputType.NonEmpty);
        c.PhoneNumber = Validation.ValidateInput(
            $"Enter {c.Name}'s Number: ", InputType.PhoneNumber);
        c.Email = Validation.ValidateInput(
            $"Enter {c.Name}'s Email: ", InputType.Email);

        _contacts.InsertContact(c);
    }

    internal void DeleteContact()
    {
        throw new NotImplementedException();
    }

    internal void UpdateContact()
    {
        throw new NotImplementedException();
    }
}
