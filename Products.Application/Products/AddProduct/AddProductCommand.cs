using MediatR;
using Products.DTO.Products;

namespace Products.Application.Products.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public AddProductCommand(AddEditProductDto data)
        {
            Data = data;
        }

        public AddEditProductDto Data { get; set; }
    }
}
