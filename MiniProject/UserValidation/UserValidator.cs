using FluentValidation;
using MiniProject.DTOs;

namespace MiniProject.UserValidation
{
    public class UserValidator : AbstractValidator<UserRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(o => o.UserName)
                .NotEmpty().WithMessage("UserName Required")
                .MinimumLength(4).WithMessage("UserName must be more than 4 characters");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email Required")
                .EmailAddress().WithMessage("Invalid Email");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password Required")
                .MinimumLength(8).WithMessage("Password must be more than 8 characters");

        }
    }
}
