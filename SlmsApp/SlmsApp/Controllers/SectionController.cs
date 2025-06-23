using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.SectionServicesBuss;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSections()
        {
            var sections = await _sectionService.GetAllSectionsAsync();
            return Ok(sections);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectionById(int id)
        {
            var section = await _sectionService.GetSectionByIdAsync(id);
            if (section == null)
                return NotFound();

            return Ok(section);
        }

        /// <summary>
        /// Handles both create and update logic for a section.
        /// If SectionId is 0 or not provided, it creates a new section.
        /// If SectionId > 0, it updates the existing section.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveSection([FromBody] SectionDto section)
        {
            if (section == null)
                return BadRequest("Section data is required.");

            if (section.SectionId > 0)
            {
                // Update existing section
                var existingSection = await _sectionService.GetSectionByIdAsync(section.SectionId);
                if (existingSection == null)
                    return NotFound($"Section with ID {section.SectionId} not found.");

                section.SectionUpdatedDate = DateTime.UtcNow;
                await _sectionService.UpdateSectionAsync(section);
                return Ok(new { message = "Section updated successfully." });
            }
            else
            {
                // Create new section
                section.SectionCreatedDate = DateTime.UtcNow;
                await _sectionService.CreateSectionAsync(section);
                return CreatedAtAction(nameof(GetSectionById), new { id = section.SectionId }, section);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            await _sectionService.DeleteSectionAsync(id);
            return NoContent();
        }

        [HttpGet("ByCourse/{courseId}")]
        public async Task<IActionResult> GetSectionsByCourseId(int courseId)
        {
            var sections = await _sectionService.GetSectionsByCourseIdAsync(courseId);
            return Ok(sections);
        }

    }
}
