using DocApi.Entities;
using DocApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch("{id}")]
        public async Task<ActionResult> ChangeRole(int id, JsonPatchDocument<Role> role)
        {
            if (_docUserRepository.DocumentNotFound(id)) return NotFound();

            var updatedRole = await _docUserRepository.ChangeRoleInDb(id, role);

            return Ok(updatedRole);
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
