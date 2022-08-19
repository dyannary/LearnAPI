using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Products.AddProduct;
using Products.Application.Products.GetProducts;
using Products.Persistence.Context;
using Products.Persistence.Entities;

namespace Products.Application.Products.EditProduct
{
    public class EditProductHandler : IRequestHandler<EditProductCommand, Unit>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public EditProductHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var prod = await _appDbContext.Products.FirstAsync(s => s.Id == request.Data.Id);

            _mapper.Map(request.Data, prod);

            await _appDbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
