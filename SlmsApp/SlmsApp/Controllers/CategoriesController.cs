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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<CategoryDto>(item));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDto dto)
        {
            var model = _mapper.Map<Category>(dto);
            model.CreatedAt = DateTime.UtcNow;
            await _service.AddAsync(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoryDto dto)
        {
            if (id != dto.CategoriesId) return BadRequest();
            var model = _mapper.Map<Category>(dto);
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