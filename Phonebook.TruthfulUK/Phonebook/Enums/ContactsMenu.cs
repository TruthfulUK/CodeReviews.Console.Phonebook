using System.ComponentModel.DataAnnotations;

namespace Phonebook.Enums;
internal enum ContactsMenu
{
    [Display(Name = "View all Contacts")]
    ViewContacts,

    [Display(Name = "Add a Contact")]
    AddContact,

    [Display(Name = "Update a Contact")]
    UpdateContact,

    [Display(Name = "Delete a Contact")]
    DeleteContact,

    [Display(Name = "Back to Main Menu")]
    BackToMainMenu
}
