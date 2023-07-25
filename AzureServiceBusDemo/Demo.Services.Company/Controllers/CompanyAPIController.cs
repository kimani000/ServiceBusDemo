using Microsoft.AspNetCore.Mvc;

namespace Demo.Services.CompanyAPI.Controllers
{
    [ApiController]
    [Route("api/company")]
    public class CompanyAPIController : ControllerBase
    {
        // GET ALL

        public IActionResult Index()
        {
            return Ok();
        }

        // GET BY ID

        // POST

        // UPDATE

        // DELETE
    }
}
