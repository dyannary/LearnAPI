using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.AddProduct;
using Products.Application.Products.DeleteProduct;
using Products.Application.Products.GetProduct;
using Products.Application.Products.GetProducts;
using Products.DTO.Products;
using Products.Persistence.Entities;
using System.Net;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<ProductDto> Get([FromRoute] int id)
        {
            return await _mediator.Send(new GetProductQuery(id));
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetProducts()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        [HttpPost]
        public async Task<int> AddProduct(AddProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<Unit> EditProduct(AddEditProductDto data)
        {
            return await _mediator.Send(new EditProductCommand(data));
        }

        [HttpDelete("{id}")]
        public async Task<Unit> DeleteProduct([FromRoute] int id)
        {
            return await _mediator.Send(new DeleteProductCommand(id));
        }
    }
}
