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
        public async Task<IActionResult> Test()
        {

            var secret = await _microsoftService.SendMail("roy@shoyer.net", "test", new List<string> { "roy.shoyer@gmail.com" });
            return Ok(secret);
        }
    }
}