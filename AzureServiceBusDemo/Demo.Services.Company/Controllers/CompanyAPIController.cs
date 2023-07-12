using Microsoft.AspNetCore.Mvc;

namespace Demo.Services.CompanyAPI.Controllers
{
    public class CompanyAPIController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
