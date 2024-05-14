using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Data;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    /// <summary>
    /// Controller for managing TechIcons.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TechIconController : Controller
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TechIconController"/> class.
        /// </summary>
        /// <param name="context">The application database context.</param>
        public TechIconController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Tech Icons.
        /// </summary>
        /// <returns>A list of Tech Icons.</returns>
        [HttpGet]
        public async Task<IActionResult> GetIcons()
        {
            var icons = await _context.TechIcons.ToListAsync();
            return Ok(icons);
        }

        /// <summary>
        /// Updates a TechIcon with a specified ID.
        /// </summary>
        /// <remarks>
        /// Sample requests:
        ///
        ///     Replace the Url property:
        ///     [
        ///         {
        ///             "path": "/Url",
        ///             "op": "replace",
        ///             "value": "Type new Image URL here"
        ///         }
        ///     ]
        /// </remarks>
        /// <param name="id">The ID of the TechIcon to update.</param>
        /// <param name="patchDoc">The JSON Patch document with updates.</param>
        /// <returns>An updated TechIcon.</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTechIcon(int id, [FromBody] JsonPatchDocument<TechIcon> patchDoc)
        {
            if (patchDoc != null)
            {
                var techIcon = await _context.TechIcons.FindAsync(id);

                if (techIcon == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(techIcon, error =>
                {
                    string errorMessage = error.ErrorMessage;
                    string affectedPath = error.AffectedObject.GetType().Name;
                    ModelState.AddModelError(affectedPath, errorMessage);
                });

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.TechIcons.Update(techIcon);
                _context.Entry(techIcon).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(techIcon);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
