using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private static readonly List<string> _projects = new() { "Proy. A", "Proy. B" };

        [HttpGet]
        public IActionResult GetAll() => Ok(_projects);

    }
}
