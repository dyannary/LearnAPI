using AutoMapper;
using Products.DTO.Products;
using Products.Persistence.Entities;

namespace Products.Application.Products
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<AddEditProductDto, Product>()
                .ForMember(x => x.Id, opts => opts.Ignore())
                .ForMember(x => x.Name, opts => opts.MapFrom(op => op.Name))
                .ForMember(x => x.Price, opts => opts.MapFrom(op => op.Price));

            CreateMap<Product, ProductDto>()
                .ForMember(x => x.Id, opts => opts.MapFrom(op => op.Id))
                .ForMember(x => x.Name, opts => opts.MapFrom(op => op.Name))
                .ForMember(x => x.Price, opts => opts.MapFrom(op => op.Price));
        }
    }
}