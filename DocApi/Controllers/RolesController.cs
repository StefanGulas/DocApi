using DocApi.Entities;
using DocApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DocApi.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IDocUserRepository _docUserRepository;

        public RolesController(IDocUserRepository docUserRepository)
        {
            _docUserRepository = docUserRepository ??
                throw new ArgumentNullException(nameof(docUserRepository));
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var role = await _docUserRepository.GetRolesAsync();
            return Ok(role);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await _docUserRepository.GetRoleAsync(id);
            if (role == null) return NotFound();

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(Role role)
        {
            if (role.RoleName is string)
            {
                _docUserRepository.AddRole(role);
            }

            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeRole(int id, Role role)
        {
            if (_docUserRepository.RoleNotFound(id)) return NotFound();
            role.RoleId = 0;
            var existingRole = await _docUserRepository.GetRoleAsync(id);
            _docUserRepository.ChangeRoleInDb(role, existingRole);

            return Ok(role);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var role = await _docUserRepository.GetRoleAsync(id);
            if (role == null) return NotFound();
            _docUserRepository.DeleteRoleInDb(role);
            return Ok();
        }
    }
}
