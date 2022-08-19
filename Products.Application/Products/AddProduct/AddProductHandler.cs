using AutoMapper;
using MediatR;
using Products.Persistence.Context;
using Products.Persistence.Entities;

namespace Products.Application.Products.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public AddProductHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var productToAdd = _mapper.Map<Product>(request.Data);

            await _appDbContext.Products.AddAsync(productToAdd);
            await _appDbContext.SaveChangesAsync();

            return productToAdd.Id;
        }
    }
}
