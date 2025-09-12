using Phonebook.Enums;
using Spectre.Console;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Phonebook.Helpers;
internal static class Validation
{
    public static string ValidateInput(string prompt, InputType inputType)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
                .Validate((string text) => Validate(inputType, text))
        );
    }

    private static ValidationResult Validate(InputType inputType, string text)
    {
        switch (inputType)
        {
            case InputType.NonEmpty:
                return string.IsNullOrWhiteSpace(text)
                ? ValidationResult.Error("[red]Input cannot be empty[/]")
                : ValidationResult.Success();
            case InputType.Email:
                return !IsEmail(text)
                ? ValidationResult.Error("[red]Enter a valid email (e.g., johndoe@example.com[/]")
                : ValidationResult.Success();
            case InputType.PhoneNumber:
                return !IsPhoneNumber(text)
                ? ValidationResult.Error("[red]Enter a valid phone (digits only or +countrycode, 8–15 digits).[/]")
                : ValidationResult.Success();
            default:
                return ValidationResult.Error("[red] Unsupported input type.[/]");
        }
    }

    private static bool IsEmail (string text)
    {
        try
        {
            var email = new MailAddress(text);
            return email.Address == text;
        }
        catch { return false; }
    }

    private static bool IsPhoneNumber(string text)
    {
        var cleaned = Regex.Replace(text, @"[\s\-\(\)]", "");
        if (!Regex.IsMatch(cleaned, @"^\+?\d{8,15}$")) return false;
        if (cleaned.StartsWith("+") && cleaned.Length > 1 && cleaned[1] == '0') return false;
        return true;
    }
}
