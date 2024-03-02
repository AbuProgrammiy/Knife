using Microsoft.AspNetCore.Mvc.Filters;     // AuthorizationFilterContext ishlashi uchun
using Project.Domen.Enums;                  // Permissions ishlashi uchun
using System.Security.Claims;               // Claim, ClaimsIdentity ishlashi uchun
using System.Text.Json;                     // JsonSerializer ishlashi uchun
using Microsoft.AspNetCore.Mvc;             // ForbidResult ishlashi uchun

namespace Project.Api.Attributes
{
    [AttributeUsage( AttributeTargets.Method )]   // Permissionlarni nmani ustida ishlatatyotganimizni yozish kerak (bizda controllerni ichida bir method ustida ishlatmoqdamiz)
    public class IdentityFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;
        public IdentityFilterAttribute(Permissions permissions)
        {
            _permissionId = (int)permissions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)  // IAuthorizationFilter interfacesini implementatsiyasi
        {
            //User authorizatsiya qilgan tokenidan rolini tekshirib va joriy permissionga ruhsati bor yoqlikga tekshiradi
            //  Ruhsati yoq bolsa Forbidden 403 qaytaradi. Aks holda hech nma qilmaydi
            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;
            string permmissionsJson = identity.FindFirst("permissions")!.Value;
            bool result=JsonSerializer.Deserialize<IEnumerable<int>>(permmissionsJson)!.Any(x=>x==_permissionId);
            if(!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
