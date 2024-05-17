using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using ProjectApi.Models;
using ProjectApi.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ProjectApi.Controllers
{
    /// <summary>
    /// Controller for managing Git projects.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GitProjectController : Controller
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitProjectController"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public GitProjectController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Git projects.
        /// </summary>
        /// <returns>A list of Git projects.</returns>
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var gitProjects = await _context.GitProjects.Include(p => p.Technologies).ThenInclude(t => t.TechIcon).ToListAsync();
            return Ok(gitProjects);
        }

        /// <summary>
        /// Creates a new Git project (Admin only)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /GitProject
        ///     {
        ///        "ProjectImg": "image_url",
        ///        "ProjectName": "Project Name",
        ///        "Technologies": [1, 2, 3] (write Id from TechIcon),
        ///        "Date": "2022-01-01",
        ///        "Description": "Project description",
        ///        "GithubUrl": "github_url",
        ///        "LiveDemoUrl": "demo_url"
        ///     }
        /// </remarks>
        /// <param name="newProject">The Git project to create.</param>
        /// <returns>A newly created Git project.</returns>
        /// <response code="201">Returns the newly created Git project.</response>
        /// <response code="400">If the Git project is null or invalid.</response> 
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProject([FromBody] GitProjectDTO newProjectDto)
        {
            if (newProjectDto == null)
            {
                return BadRequest("Project data is null");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProject = new GitProject
            {
                ProjectImg = newProjectDto.ProjectImg,
                ProjectName = newProjectDto.ProjectName,
                Date = newProjectDto.Date,
                Description = newProjectDto.Description,
                GithubUrl = newProjectDto.GithubUrl,
                LiveDemoUrl = newProjectDto.LiveDemoUrl
            };

            foreach (var techIconId in newProjectDto.Technologies)
            {
                var techIcon = await _context.TechIcons.FindAsync(techIconId);
                if (techIcon != null)
                {
                    newProject.Technologies.Add(new TechStack { TechIcon = techIcon });
                }
            }

            await _context.GitProjects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProjects), new { id = newProject.Id }, newProject);
        }




        /// <summary>
        /// Updates a Git project with a specified ID (Admin only)
        /// </summary>
        /// <remarks>
        /// Sample requests:
        ///
        ///     Replace the ProjectName property:
        ///     [
        ///         {
        ///             "path": "/ProjectName",
        ///             "op": "replace",
        ///             "value": "Type new title here"
        ///         }
        ///     ]
        /// </remarks>
        /// <param name="id">The ID of the Git project to update.</param>
        /// <param name="patchDoc">The JSON Patch document with updates.</param>
        /// <returns>An updated Git project.</returns>
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PatchProject(int id, [FromBody] JsonPatchDocument<GitProject> patchDoc)
        {
            if (patchDoc != null)
            {
                var gitProject = await _context.GitProjects.FindAsync(id);

                if (gitProject == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(gitProject, error =>
                {
                    string errorMessage = error.ErrorMessage;
                    string affectedPath = error.AffectedObject.GetType().Name;
                    ModelState.AddModelError(affectedPath, errorMessage);
                });

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.GitProjects.Update(gitProject);
                _context.Entry(gitProject).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(gitProject);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Deletes a Git project with a specified ID (Admin only)
        /// </summary>
        /// <param name="id">The ID of the Git project to delete.</param>
        /// <returns>No content.</returns>
        /// <response code="204">If the Git project is deleted successfully.</response>
        /// <response code="404">If the Git project is not found.</response> 
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var gitProject = await _context.GitProjects.Include(p => p.Technologies).FirstOrDefaultAsync(p => p.Id == id);

            if (gitProject == null)
            {
                return NotFound();
            }

            _context.TechStacks.RemoveRange(gitProject.Technologies);
            _context.GitProjects.Remove(gitProject);
            await _context.SaveChangesAsync();

            var remainingProjects = await _context.GitProjects.ToListAsync();

            return Ok(remainingProjects);
        }


    }
}
