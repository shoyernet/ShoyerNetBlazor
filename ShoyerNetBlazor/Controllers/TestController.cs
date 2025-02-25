using Microsoft.AspNetCore.Mvc;
using ShoyerNetBlazor.BL.Interfaces;

namespace ShoyerNetBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMicrosoftService _microsoftService;

        public TestController(IMicrosoftService microsoftService)
        {
            _microsoftService = microsoftService;
        }

        [HttpGet]
        public IActionResult Test()
        {

            var secret = _microsoftService.SendMail("roy@shoyer.net", "test", "test");
            return Ok(secret);
        }
    }
}