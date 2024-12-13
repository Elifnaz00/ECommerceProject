using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.CQRS.Contacts.Commands.Request;

namespace MyProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs([FromBody]ContactUsCommandRequest contactUsCommandRequest)
        {
            
            var responseBool= await _mediator.Send(contactUsCommandRequest);
           
            return Ok(responseBool);
        }
    }
}
