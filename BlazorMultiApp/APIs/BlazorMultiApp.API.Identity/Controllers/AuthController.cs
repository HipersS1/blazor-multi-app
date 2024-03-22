using BlazorMultiApp.Identity.Service.Commands;
using BlazorMultiApp.Identity.Service.DTOs.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiApp.Identity.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // POST api/<AuthController>
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] AuthenticateRequestDto request)
        {
            var result = await _mediator.Send(new AuthenticateCommand(request));

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First());
            }

            return Ok(result.Value);
        }

        [HttpGet("sign-out")]
        public async Task<IActionResult> SignOut()
        {
            var result = await _mediator.Send(new SignOutCommand());

            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First());
            }

            return Ok();
        }

        // GET: api/<AuthController>
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("sign-in-return")]
        public IEnumerable<string> SignInCallback()
        {
            return new string[] { "value1", "value2" };
        }

        //// GET api/<AuthController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// PUT api/<AuthController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AuthController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
