# Phonebook

[The Phonebook Project](https://thecsharpacademy.com/project/16/phonebook) is a CSharpAcademy roadmap project that introduces you to using Entity Framework Core.

Developed with C#, Entity Framework Core and Spectre Console.

# Requirements:
:white_check_mark: This is an application where you should record contacts with their phone numbers.
:white_check_mark: Users should be able to Add, Delete, Update and Read from a database, using the console.
:white_check_mark: You need to use Entity Framework, raw SQL isn't allowed.
:white_check_mark: Your code should contain a base Contact class with AT LEAST {Id INT, Name STRING, Email STRING and Phone Number(STRING)}
:white_check_mark: You should validate e-mails and phone numbers and let the user know what formats are expected
:white_check_mark: You should use Code-First Approach, which means EF will create the database schema for you.
:white_check_mark: You should use SQL Server, not SQLite

# Dependencies
- Spectre.Console (0.50.0)
- Microsoft.EntityFrameworkCore.SqlServer (9.0.8)
- Microsoft.EntityFrameworkCore.Tools (9.0.8)

# Features

### :raising_hand: Contacts
The Phonebook is able to store contacts with a name, phone number, email and optional category. If you opt to not set a category for your contact, it will default assign them to the `Unassigned` category. You can view all of your currently stored contacts in alphabetical order from the main menu using the "View Contacts" option.

New contacts can be added under the "Manage Contacts" menu. After a contact is created they can be updated and deleted as needed.

### :file_folder: Categories
The Phonebook app initializes with default 4 default categories: `Unassigned`, `Family`, `Friends` and `Work`. All categories except for `Unassigned` can be deleted.

New Categories can be created in the "Manage Categories" menu. After a contact is created they can be updated and deleted as needed. If a category is deleted, all contacts within that category will be moved to the `Unassigned` category.

# Learning Outcome
- Separating input and data logic keeps things extremely tidy. By having a Contact and Category service to handle the input and a Controller to handle the data operations I ran into less errors and easier navigation of my project.
- Spectre Console UseConverter method is really handy for being able to display properties from an object while still allow you to capture the whole object on selection.
- Don't seed dummy data you want to modify / change within the OnConfiguring override, you will need to do a migration to change the data and you also need to manually assign primary identifiers. Instead keep any data initialized here to purely default data (e.g., categories) and seed dummy data from another class / method.

# Resources Used
- [Entity Framework Tutorial - Entity Framework Core](https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx)
- [Microsoft Learn - Overview of Entity Framework Core)](https://learn.microsoft.com/en-us/ef/core/) 
- [Spectre Console Docs](https://spectreconsole.net/)
- ChatGPT (models: 5, 4o)
- Gemini (models: 2.5 Pro)