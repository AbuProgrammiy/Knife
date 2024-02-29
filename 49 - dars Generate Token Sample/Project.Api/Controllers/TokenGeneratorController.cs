using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;                     // ControllerBase ishlashi uchun
using Project.Application.Services.AuthServices;    // IAuthService ishlashi uchun
using Project.Domen.Entities.Models;                // User modeli ishlashi uchun

namespace Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenerateTokenController : ControllerBase
    {
        private readonly IAuthService _service;

        public GenerateTokenController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost]
        public string GeneratorToken(User user)
        {
            return _service.GenerateToken(user);
        }
    }
}
