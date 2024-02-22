using BlazorMultiApp.Identity.Service.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiApp.Identity.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // POST api/<AuthController>
        [HttpPost("sign-in")]
        public IActionResult Post([FromBody] CreateUserRequestDto request)
        {
            return Ok();
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
