using MediatR;
using Products.DTO.Products;
using Products.Persistence.Entities;

namespace Products.Application.Products.AddProduct
{
    public class EditProductCommand : IRequest<Unit>
    {
        public EditProductCommand(AddEditProductDto data)
        {
            Data = data;
        }
        public AddEditProductDto Data { get; set; }
    }
}
