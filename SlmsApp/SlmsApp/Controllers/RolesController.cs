using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.Roles;
using SlmsAppDataAccess.Models;
using SlmsAppModels;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(roles));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
                return NotFound();

            return Ok(_mapper.Map<RoleDto>(role));
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> PostRole(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            role.CreatedAt = DateTime.UtcNow;
            role.UpdatedAt = DateTime.UtcNow;

            await _roleService.CreateRoleAsync(role);

            return CreatedAtAction(nameof(GetRole), new { id = role.RolesId }, _mapper.Map<RoleDto>(role));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleDto roleDto)
        {
            if (id != roleDto.RolesId)
                return BadRequest();

            var role = _mapper.Map<Role>(roleDto);
            role.UpdatedAt = DateTime.UtcNow;

            await _roleService.UpdateRoleAsync(role);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }

}
