﻿using Microsoft.AspNetCore.Mvc;
using ProjectApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using ProjectApi.Models;

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
        /// Updates a Git project with a specified ID.
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
    }
}
