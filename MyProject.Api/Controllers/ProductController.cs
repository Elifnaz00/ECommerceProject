using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.CQRS.Products.Queries.Request;


namespace MyProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]


    // return RedirectToAction(nameof(Index));
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(result);
        }



        [HttpGet("GetNewArrivalProducts")]
        public async Task<IActionResult> GetNewArrivalProducts() 
        {
            var value= await _mediator.Send(new GetNewProductsQueryRequest());
            return Ok(value);
        
        }



        [HttpGet("Productbycategory/{id}")]
        public async Task<IActionResult> GetProductByCategory(Guid id)
        {
            var result = await _mediator.Send(
                new GetProductByCategoryQueryRequest
                {
                    Id = id
                }
            );

            return Ok(result);
        }



        [HttpGet("Productdetail/{id}")]
        public async Task<IActionResult> GetProductDetail(Guid id)
        {
            var result = await _mediator.Send(new GetProductDetailQueryRequest { Id = id });
            return Ok(result);
        }




        [HttpGet("GetFiltered")]
        
        public async Task<IActionResult> GetFilteredProduct([FromQuery] string category, [FromQuery] string size, [FromQuery] string color, [FromQuery] string price)
        {


           
            var result = await _mediator.Send(new GetFilteredProductQueryRequest { category = category, color = color, price = price, size = size } );
            return Ok(result); 
           
        }



    }
}
