using Phonebook.Enums;
using Phonebook.Helpers;
using Phonebook.Services;
using Spectre.Console;

namespace Phonebook.Views;
internal class AppView
{
    private readonly ContactService _contacts;

    public AppView()
    {
        _contacts = new ContactService();
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();

            Display.DisplayHeader("Main Menu");

            var mainMenuOptions = Display.GetMenuOptions<MainMenu>();
            var mainMenuChoice = Display.SelectionPrompt(mainMenuOptions);

            switch (mainMenuChoice)
            {
                case MainMenu.SearchContacts:
                    break;
                case MainMenu.ManageContacts:
                    var contactsMenuOptions = Display.GetMenuOptions<ContactsMenu>();
                    var contactsMenuChoice = Display.SelectionPrompt(contactsMenuOptions);
                    switch (contactsMenuChoice)
                    {
                        case ContactsMenu.ViewContacts:
                            _contacts.ViewContacts();
                            break;
                        case ContactsMenu.AddContact:
                            _contacts.AddContact();
                            break;
                        case ContactsMenu.UpdateContact:
                            _contacts.UpdateContact();
                            break;
                        case ContactsMenu.DeleteContact:
                            _contacts.DeleteContact();
                            break;
                        case ContactsMenu.BackToMainMenu:
                            break;
                    }
                    break;
                case MainMenu.ManageCategories:
                    var categoriesMenuOptions = Display.GetMenuOptions<CategoriesMenu>();
                    var categoriesMenuChoice = Display.SelectionPrompt(categoriesMenuOptions);
                    switch (categoriesMenuChoice)
                    {
                        case CategoriesMenu.AddCategory:
                            break;
                        case CategoriesMenu.UpdateCategory:
                            break;
                        case CategoriesMenu.DeleteCategory:
                            break;
                        case CategoriesMenu.BackToMainMenu:
                            break;
                    }
                    break;
                case MainMenu.ExitApplication:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
