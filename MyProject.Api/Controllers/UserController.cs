using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MyProject.DataAccess.CQRS.AppUsers.Commands.Request;

namespace MyProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        


        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
           
                var response= await _mediator.Send(createUserCommandRequest);

                if(response.Succeeded== true)
                {
                   
                    return StatusCode(201, response.Message);
                }
                else
                return BadRequest(response.Message);
            
            
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            var response= await _mediator.Send(loginUserCommandRequest);

            if (response.Contains("Giriş Başarılı"))
            {
                return Ok(response);
            }
            else
                return BadRequest(response);
                
        }



        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutUser()
        {

            return Ok();
        }



    }
}
