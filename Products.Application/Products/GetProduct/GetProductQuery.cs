using MediatR;
using Products.DTO.Products;

namespace Products.Application.Products.GetProduct
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public GetProductQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; } 
    }
}
