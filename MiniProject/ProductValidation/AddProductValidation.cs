using FluentValidation;
using MiniProject.DTOs;

namespace MiniProject.ProductValidation
{
    public class AddProductValidation :AbstractValidator<AddProductDto>
    {
        public AddProductValidation()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name is required")
                .MinimumLength(3).WithMessage("Product Name must be at least 3 characters long");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category Id must be greater than 0");
        }
    }
}
