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

        try
        {
            _contacts.InsertContact(c);
            AnsiConsole.MarkupLine($"[Green]Success:[/] {c.Name} has been successfully added to your contact list!");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] Could not add contact {c.Name}: {ex.Message}");
        }

        Display.PressKeyToContinue();
    }

    internal void DeleteContact()
    {
        throw new NotImplementedException();
    }

    internal void UpdateContact()
    {
        throw new NotImplementedException();
    }

    internal void ViewContacts(bool viewOnly = true)
    {

        Display.DisplayHeader("Viewing All Contacts");

        List<Contact> contacts = _contacts.SelectAllContacts().OrderBy(x => x.Name).ToList();

        if (contacts.Count == 0)
        {
            AnsiConsole.MarkupLine($"[blue]Oh dear![/] It doesn't appear you have any contacts to display.");
            Display.PressKeyToContinue();
            return;
        }

        var contactTable = new Table();
        contactTable
            .AddColumn("[white on blue] Contact Name [/]")
            .AddColumn("[white on blue] Contact Category [/]")
            .AddColumn("[white on blue] Contact Phone # [/]")
            .AddColumn("[white on blue] Contact Email [/]")
            .ShowRowSeparators()
            .Border(TableBorder.Horizontal)
            .Expand();

        foreach (Contact contact in contacts)
        {
            contactTable.AddRow(
                $"{contact.Name}",
                $"{contact.Category.Name}",
                $"{contact.PhoneNumber}",
                $"{contact.Email}");
        }

        AnsiConsole.Write(contactTable);

        if (viewOnly) Display.PressKeyToContinue();
    }
}
