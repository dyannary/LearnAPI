using MediatR;
using Products.Persistence.Entities;

namespace Products.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
