using Google.Cloud.SecretManager.V1;
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
            // The client picks up credentials from GOOGLE_APPLICATION_CREDENTIALS
            SecretManagerServiceClient client = SecretManagerServiceClient.Create();

            // Build the resource name for the secret version
            SecretVersionName secretVersionName = new SecretVersionName("we4u-blazor", "TenantId", "latest");

            // Access the secret version.
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);

            // Extract the secret payload as a string.
            string secretPayload = result.Payload.Data.ToStringUtf8();
           

            return Ok(secretPayload);
        }
    }
}