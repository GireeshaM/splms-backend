using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.GetCoursesServices;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetCoursesController : ControllerBase
    {
        private readonly IGetCourseService _service;

        public GetCoursesController(IGetCourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllCoursesAsync());

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategory(int id) => Ok(await _service.GetCoursesByCategoryAsync(id));

        [HttpGet("subcategory/{id}")]
        public async Task<IActionResult> GetBySubCategory(int id) => Ok(await _service.GetCoursesBySubCategoryAsync(id));

        [HttpGet("level/{level}")]
        public async Task<IActionResult> GetByLevel(string level) => Ok(await _service.GetCoursesByLevelAsync(level));

        [HttpGet("duration/{duration}")]
        public async Task<IActionResult> GetByDuration(string duration) => Ok(await _service.GetCoursesByDurationAsync(duration));

        [HttpGet("skill/{skill}")]
        public async Task<IActionResult> GetBySkill(string skill) => Ok(await _service.GetCoursesBySkillAsync(skill));

        [HttpGet("levels")]
        public async Task<IActionResult> GetLevels() => Ok(await _service.GetAllLevelsAsync());

        [HttpGet("durations")]
        public async Task<IActionResult> GetDurations() => Ok(await _service.GetAllDurationsAsync());

        [HttpGet("skills")]
        public async Task<IActionResult> GetSkills() => Ok(await _service.GetAllSkillsAsync());
        [HttpGet("subcategories")]
        public async Task<IActionResult> GetSubCategories() => Ok(await _service.GetAllSubCategoriesAsync());

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories() => Ok(await _service.GetAllCategoriesAsync());


    }
}
