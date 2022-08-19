using FluentValidation;
using Products.Application.Products.AddProduct;

public class AddProductValidator : AbstractValidator<AddProductCommand>
{
    public AddProductValidator()
    {
        RuleFor(x => x.Data)
            .Must(x=>CheckEmail(x.Name))
            .WithMessage("Nume gol");
    }

    private bool CheckEmail(string email)
    {
        return true;
    }
}