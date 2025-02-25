using Microsoft.AspNetCore.Mvc;

namespace ShoyerNetBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {  
        [HttpGet]
        public IActionResult Test()
        {
           
            return Ok(secretPayload);
        }
    }
}