using FluentValidation;
using Products.Persistence.Context;

namespace Products.Application.Products.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductValidator(AppDbContext appDbContext)
        {
            RuleFor(x => x.Id)
             .Must(x => appDbContext.Products.Any(p => p.Id == x))
             .WithMessage("Nu exista asa Id bai pula");
        }
    }
}