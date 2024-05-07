using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitProjectController : Controller
    {
        [HttpGet]
        public IActionResult GetProjects()
        {
            var gitProjects = DataInitializer.Projects;
            return Ok(gitProjects);
        }

    }
}
