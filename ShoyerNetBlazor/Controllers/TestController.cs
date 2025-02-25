using Microsoft.AspNetCore.Mvc;
using ShoyerNetBlazor.BL.Interfaces;

namespace ShoyerNetBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IGoogleCloudServices _googleServices;

        public TestController(IGoogleCloudServices googleServices)
        {
            _googleServices = googleServices;
        }

        [HttpGet]
        public IActionResult Test()
        {

            var secret = _googleServices.GetSecret("TenantId");
            return Ok(secret);
        }
    }
}