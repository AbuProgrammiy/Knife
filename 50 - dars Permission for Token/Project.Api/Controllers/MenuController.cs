using Microsoft.AspNetCore.Authorization;   // Authorize ishlashi uchun
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //ushbu amal joriy Controller methodlarini avtorizatsiyasiz ishlatishdan saqlaydi. Methodlar ustiga qoysa ham bo'ladi!
    public class MenuController : ControllerBase
    {
        [HttpGet]
        public string Greeting()
        {
            return "Hello, You are authorized";
        }
    }
}
