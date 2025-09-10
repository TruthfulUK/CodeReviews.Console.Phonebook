using System.ComponentModel.DataAnnotations;

namespace Phonebook.Enums;
internal enum MainMenu
{
    [Display(Name = "Search Contacts")]
    SearchContacts,

    [Display(Name = "Manage Contacts")]
    ManageContacts,

    [Display(Name = "Manage Categories")]
    ManageCategories,

    [Display(Name = "Exit Application")]
    ExitApplication  
}
