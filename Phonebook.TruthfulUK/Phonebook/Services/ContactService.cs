using Phonebook.Controllers;
using Phonebook.Enums;
using Phonebook.Helpers;
using Phonebook.Models;
using Spectre.Console;

namespace Phonebook.Services;
internal class ContactService
{
    private readonly ContactController _contacts;
    private readonly CategoryController _categories;
    private readonly List<int> _validRowIds;

    public ContactService()
    {
        _contacts = new ContactController();
        _categories = new CategoryController();
        _validRowIds = new List<int>();
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
        Display.DisplayHeader("Delete Contact");

        ViewContacts(viewOnly: false);

        int id = Validation.ValidateRowId(_validRowIds);

        if (id == 0) return;

        try
        {
            _contacts.DeleteContact(id);
            AnsiConsole.MarkupLine($"[green]Success:[/] Contact has been deleted.");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] Could not delete contact - {ex.Message}");
        }

        Display.PressKeyToContinue();
    }

    internal void UpdateContact()
    {

        Display.DisplayHeader("Update Contact");

        ViewContacts(viewOnly: false);

        int id = Validation.ValidateRowId(_validRowIds);
        if (id == 0) return;

        Contact contact = _contacts.SelectContactById(id);

        Display.DisplayHeader($"Updating Details for '{contact.Name}'");

        var updateOptions = Display.GetMenuOptions<UpdateValue>();
        var updateChoice = Display.SelectionPrompt(updateOptions);

        switch (updateChoice)
        {
            case UpdateValue.UpdateName:
                string newName = Validation.ValidateInput(
                    $"Enter Updated Name for {contact.Name}: ", 
                    InputType.NonEmpty);
                _contacts.UpdateContactName(id, newName);
            break;
            case UpdateValue.UpdateNumber:
                string newNumber = Validation.ValidateInput(
                    $"Enter New Number for {contact.Name}: ",
                    InputType.PhoneNumber);
                _contacts.UpdatePhoneNumber(id, newNumber);
            break;
            case UpdateValue.UpdateEmail:
                string newEmail = Validation.ValidateInput(
                    $"Enter New Email for {contact.Name}: ",
                    InputType.PhoneNumber);
                _contacts.UpdateEmail(id, newEmail);
            break;
            case UpdateValue.UpdateCategory:
                break;
        }

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
            .AddColumn("[white on blue] ID [/]")
            .AddColumn("[white on blue] Contact Name [/]")
            .AddColumn("[white on blue] Category [/]")
            .AddColumn("[white on blue] Phone # [/]")
            .AddColumn("[white on blue] Email [/]")
            .ShowRowSeparators()
            .Border(TableBorder.Horizontal)
            .Expand();

        _validRowIds.Clear();

        foreach (Contact contact in contacts)
        {
            contactTable.AddRow(
                $"{contact.Id}",
                $"{contact.Name}",
                $"{contact.Category.Name}",
                $"{contact.PhoneNumber}",
                $"{contact.Email}");
            _validRowIds.Add(contact.Id);
        }

        AnsiConsole.Write(contactTable);

        if (viewOnly) Display.PressKeyToContinue();
    }
}
