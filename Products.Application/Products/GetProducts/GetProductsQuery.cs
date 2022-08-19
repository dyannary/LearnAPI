using MediatR;
using Products.DTO.Products;

namespace Products.Application.Products.GetProducts
{
    public record GetAllProductsQuery : IRequest<List<ProductDto>>;
}
