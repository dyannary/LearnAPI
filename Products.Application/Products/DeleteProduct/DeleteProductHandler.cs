using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Persistence.Context;

namespace Products.Application.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteProductHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _appDbContext.Products.FirstAsync(p => p.Id == request.Id);
            
            _appDbContext.Products.Remove(productToDelete);
            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
