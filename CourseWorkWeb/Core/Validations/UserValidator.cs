using CourseWorkWeb.Models.Entity.Auth;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CourseWorkWeb.Core.Validations
{
    public class UserValidator : AbstractValidator<Account>
    {
            public UserValidator()
            {
                RuleFor(u => u.Username)
                    .NotEmpty()
                    .MaximumLength(30)
                    .Matches("^[a-zA-Z0-9_]*$");

                RuleFor(u => u.Email)
                    .NotEmpty()
                    .Matches(@"^[\w-]+(?:\.[\w-]+)*@gmail\.com$")
                    .MinimumLength(12);

                RuleFor(u => u.Password.PasswordValue)
                    .NotEmpty()
                    .MinimumLength(12)
                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{12,}$");
            }

            public static bool IsUsernameValid(string username)
            {
                return !string.IsNullOrEmpty(username) &&
                       username.Length <= 30 &&
                       Regex.IsMatch(username, "^[a-zA-Z0-9_]*$");
            }

            public static bool IsEmailValid(string email)
            {
                return !string.IsNullOrEmpty(email) &&
                       Regex.IsMatch(email, @"^[\w-]+(?:\.[\w-]+)*@gmail\.com$") &&
                       email.Length >= 12;
            }

            public static bool IsPasswordValid(string password)
            {
                return !string.IsNullOrEmpty(password) && password.Length >= 12 && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{12,}$");
            }
        }
    }

