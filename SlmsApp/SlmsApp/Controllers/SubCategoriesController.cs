using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.CategoriesServices;
using SlmsAppDataAccess.Models;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategoryService _service;
        private readonly IMapper _mapper;

        public SubCategoriesController(ISubCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> GetByCategory(int categoryId)
        {
            var data = await _service.GetByCategoryIdAsync(categoryId);
            return Ok(_mapper.Map<IEnumerable<SubCategoryDto>>(data));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<SubCategoryDto>>(data));
        }

        [HttpPost]
        public async Task<ActionResult> Create(SubCategoryDto dto)
        {
            var model = _mapper.Map<SubCategory>(dto);
            model.CreatedAt = DateTime.UtcNow;
            model.UpdatedAt = DateTime.UtcNow;
            await _service.AddAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SubCategoryDto dto)
        {
            if (id != dto.SubCategoriesId) return BadRequest();
            var model = _mapper.Map<SubCategory>(dto);
            model.UpdatedAt = DateTime.UtcNow;
            await _service.UpdateAsync(model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}