using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;   // Authorize ishlashi uchun
using Microsoft.AspNetCore.Mvc;             // ControllerBaseishlashi uchun
using Project.Api.Attributes;               // IdentityFilter ishlashi uchun
using Project.Domen.Enums;                  // Permissions ishlashi uchun

namespace Project.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]  // IdentityFilter bolishiga qaramasda buni ham yozib qoyish kerak, chunki user authorizatsiya qilmasdan ushbu methodni ishlatsa 403, agar yozib qoyilmasa 500 qaytaradi
    public class MenuController : ControllerBase
    {
        [HttpGet]
        [IdentityFilter(Permissions.ShowTeachers)]  // ShowTeachers permissioniga ega userlar ushbu methodni ishlata oladi
        public IEnumerable<string> TeachersList()
        {
            return ["MuhammadAbdulloh","MuhammadKarim","Shodmon Shoyimovich","Alisher Kasimov"];
        }

        [HttpGet]
        [IdentityFilter(Permissions.ShowStudents)]  // ShowStudent permissioniga ega userlar ushbu methodni ishlata oladi
        public IEnumerable<string> StudentsList()
        {
            return ["Abduxoliq","Ozod","Ibrohim","Toxir"];
        }
    }
}
