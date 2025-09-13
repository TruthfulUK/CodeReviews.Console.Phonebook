using Phonebook.Controllers;
using Phonebook.Enums;
using Phonebook.Helpers;
using Phonebook.Models;
using Spectre.Console;

namespace Phonebook.Services;
internal class CategoryService
{
    private readonly CategoryController _categories;

    public CategoryService()
    {
        _categories = new CategoryController();
    }

    internal void AddCategory()
    {
        Display.DisplayHeader("Add a New Category");

        string categoryName = Validation.ValidateInput(
            "Enter Name for New Category: ", InputType.NonEmpty);

        try
        {
            _categories.InsertCategory(categoryName);
            AnsiConsole.MarkupLine($"[green]Success:[/] Added new category: {categoryName}");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
        }

        Display.PressKeyToContinue();
    }

    internal void UpdateCategory()
    {
        Display.DisplayHeader("Update a Category");

        List<Category> categories = _categories.SelectAllCategories();

        var selectedCategory = AnsiConsole.Prompt(
                    new SelectionPrompt<Category>()
                    .Title("Select a Category to update: ")
                    .UseConverter(c => c.Name)
                    .AddChoices(categories));

        string categoryName = Validation.ValidateInput(
            $"Enter New Name for {selectedCategory.Name}: ", InputType.NonEmpty);

        try
        {
            _categories.UpdateCategory(selectedCategory.CategoryId, categoryName);
            AnsiConsole.MarkupLine($"[green]Success:[/] Updated category name to {categoryName}");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
        }
        
        Display.PressKeyToContinue();
    }

    internal void DeleteCategory()
    {
        Display.DisplayHeader("Delete a Category");

        List<Category> categories = _categories.SelectAllCategories();

        var selectedCategory = AnsiConsole.Prompt(
                    new SelectionPrompt<Category>()
                    .Title("Select a Category to delete: ")
                    .UseConverter(c => c.Name)
                    .AddChoices(categories));

        if (selectedCategory.CategoryId == 1)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] You cannot delete the 'Unassigned' category. as this is the default for new contacts.");
            Display.PressKeyToContinue();
            return;
        }

        try
        {
            _categories.DeleteCategory(selectedCategory.CategoryId);
            AnsiConsole.MarkupLine($"[green]Success:[/] deleted category '{selectedCategory.Name}'");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
        }

        Display.PressKeyToContinue();
    }
}
