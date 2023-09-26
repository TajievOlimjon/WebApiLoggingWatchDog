using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            WatchDog.WatchLogger.Log("Get All users ");
            var list = new List<string>() { "Olimjon", "Ahmadjon","Azamjon" };
            return Ok(list);
        }
    }
}
