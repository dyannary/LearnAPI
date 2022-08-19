using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.DTO.Products;
using Products.Persistence.Context;
using Products.Persistence.Entities;

namespace Products.Application.Products.GetProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _appDbContext.Products.ToListAsync();

            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
