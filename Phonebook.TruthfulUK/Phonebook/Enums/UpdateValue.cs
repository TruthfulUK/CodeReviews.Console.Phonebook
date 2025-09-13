using System.ComponentModel.DataAnnotations;

namespace Phonebook.Enums;
internal enum UpdateValue
{
    [Display(Name = "Update Name")]
    UpdateName,

    [Display(Name = "Update Phone Number")]
    UpdateNumber,

    [Display(Name = "Update Email")]
    UpdateEmail,

    [Display(Name = "Update Category")]
    UpdateCategory
}
