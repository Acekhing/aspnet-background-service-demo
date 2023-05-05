using Microsoft.AspNetCore.Mvc;

namespace aspnet_background_service_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
