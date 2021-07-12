using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystemBackend.ViewModel;
using InventoryManagementSystemBackend.Data;
using InventoryManagementSystemBackend.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryManagementSystemBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IJwtAuthManager jwtAuthManager;
        private readonly InventoryManagementSystemBackendContext _context;

        public LoginController(IJwtAuthManager jwtAuth, InventoryManagementSystemBackendContext context)
        {
            this.jwtAuthManager = jwtAuth;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserLogin userLogin)
        {
           var entity = _context.Admin.Where(p => p.Email == userLogin.email && p.Password == userLogin.password).FirstOrDefault();
             if (entity != null)
              {
                var token = jwtAuthManager.Authenticate(userLogin.email, userLogin.password);
                 if (token == null) return Unauthorized();
                  else
                   {
                      verifiedData user = new verifiedData();
                      user.data = entity;
                      user.token = token;

                      return Ok(user);
                       }
                   }

                   return Unauthorized();
        }

        [HttpGet("name")]
        public IEnumerable<string> Get() {
            return new string[] {"value1", "value2"};
        }
    }

    public class verifiedData
    {
         public object data { get; set; }
         public string token { get; set; }
    }
}
