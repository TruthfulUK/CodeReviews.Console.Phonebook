using System.ComponentModel.DataAnnotations;

namespace Phonebook.Enums;
internal enum CategoriesMenu
{
    [Display(Name = "Add a Category")]
    AddCategory,

    [Display(Name = "Update a Category")]
    UpdateCategory,

    [Display(Name = "Delete a Category")]
    DeleteCategory,

    [Display(Name = "Back to Main Menu")]
    BackToMainMenu
}
