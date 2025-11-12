using Microsoft.AspNetCore.Mvc;

namespace Assignment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private static readonly List<string> _assignments = new() { "Tarea 1", "Tarea 2" };

        [HttpGet]
        public IActionResult GetAll() => Ok(_assignments);
    }
}
