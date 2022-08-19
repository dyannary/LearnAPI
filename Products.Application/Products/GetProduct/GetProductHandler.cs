using MediatR;
using Products.Persistence.Entities;
using Products.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Products.DTO.Products;
using AutoMapper;

namespace Products.Application.Products.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetProductHandler(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        } 

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        { 
            var prod = await _appDbContext.Products.FirstAsync(p => p.Id == request.Id);

            return _mapper.Map<ProductDto>(prod);
        }
    }
}
