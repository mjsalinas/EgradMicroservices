using Microsoft.AspNetCore.Mvc;

namespace Evaluation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationController : ControllerBase
    {
        private static readonly List<string> _evaluations = new() { "Evaluacion 1", "Evaluacion 2" };

        [HttpGet]
        public IActionResult GetAll() => Ok(_evaluations);
    }
}
