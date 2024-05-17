using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Data;
using ProjectApi.Models;
using ProjectApi.Models.DTO;

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
        /// Creates a new TechIcon (Admin only)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /TechIcon
        ///     {
        ///        "Technology": "Technology Name",
        ///        "Url": "icon_url"
        ///     }
        /// </remarks>
        /// <param name="newTechIconDto">The TechIcon to create.</param>
        /// <returns>A newly created TechIcon.</returns>
        /// <response code="201">Returns the newly created TechIcon.</response>
        /// <response code="400">If the TechIcon is null or invalid.</response> 
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTechIcon([FromBody] TechIconDTO newTechIconDto)
        {
            if (newTechIconDto == null)
            {
                return BadRequest("TechIcon data is null");
            }

            var newTechIcon = new TechIcon
            {
                Technology = newTechIconDto.Technology,
                Url = newTechIconDto.Url
            };

            await _context.TechIcons.AddAsync(newTechIcon);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIcons), new { id = newTechIcon.Id }, newTechIcon);
        }



        /// <summary>
        /// Updates a TechIcon with a specified ID (Admin only)
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
        [Authorize(Roles = "Admin")]
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

        /// <summary>
        /// Deletes a TechIcon with a specified ID (Admin only)
        /// </summary>
        /// <param name="id">The ID of the TechIcon to delete.</param>
        /// <returns>No content.</returns>
        /// <response code="204">If the TechIcon is deleted successfully.</response>
        /// <response code="404">If the TechIcon is not found.</response> 
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTechIcon(int id)
        {
            var techIcon = await _context.TechIcons.FindAsync(id);

            if (techIcon == null)
            {
                return NotFound();
            }

            _context.TechIcons.Remove(techIcon);
            await _context.SaveChangesAsync();

            var remainingIcons = await _context.TechIcons.ToListAsync();

            return Ok(remainingIcons);
        }

    }
}
