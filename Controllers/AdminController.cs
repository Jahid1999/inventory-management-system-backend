using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagementSystemBackend.Data;
using InventoryManagementSystemBackend.Model;
using InventoryManagementSystemBackend.Repository;

namespace InventoryManagementSystemBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // private readonly InventoryManagementSystemBackendContext _context;

        // public AdminController(InventoryManagementSystemBackendContext context)
        // {
        //     _context = context;
        // }

        public readonly AdminRepository _adminRepository = new AdminRepository();

        // GET: api/admin
        [HttpGet]
        public IActionResult GetAdmin()
        {
            var admins = _adminRepository.getAllAdmins();

            return  Ok(admins);
        }

        // GET: api/admin/5
        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            var admin = _adminRepository.getAdminById(id);

            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }


        // POST: api/admin/register
        [HttpPost("register")]
        public IActionResult PostAdmin([FromBody] Admin admin)
        {
            var newAdmin = _adminRepository.addAdmin(admin);
        
            return Ok(newAdmin);
        }

        // PUT: api/admin/update
        [HttpPut("update")]
        public IActionResult PutAdmin([FromBody] Admin admin)
        {
            var updated_admin = _adminRepository.updateAdmin(admin);
        
            return Ok(updated_admin);
        }

        // DELETE: api/admin/delete/5
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
        
            var isDeleted = _adminRepository.deleteAdmin(id);
            if (!isDeleted){
                return NotFound();
            }

            return Ok("Admin deleted Successfully.");
        }

    }
}
