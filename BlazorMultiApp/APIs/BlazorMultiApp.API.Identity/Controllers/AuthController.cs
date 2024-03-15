using BlazorMultiApp.Identity.Service.Commands;
using BlazorMultiApp.Identity.Service.DTOs.Request;
using MediatR;
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
        public async Task<IActionResult> Post([FromBody] AuthenticateRequestDto request)
        {
            var result = await _mediator.Send(new AuthenticateCommand(request));

            return Ok(result);
        }

        //// GET: api/<AuthController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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
