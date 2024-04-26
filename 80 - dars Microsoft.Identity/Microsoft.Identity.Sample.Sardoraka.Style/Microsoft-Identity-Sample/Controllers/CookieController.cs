using Microsoft.AspNetCore.Mvc;

namespace Microsoft_Identity_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CookieController : ControllerBase
    {
        [HttpGet]
        public IRequestCookieCollection GetAllCookies()
        {
            return HttpContext.Request.Cookies;
        }

        [HttpPost]
        public string AppendToCookies(string key, string value)
        {
            HttpContext.Response.Cookies.Append(key, value);
            //                   ^^^^^^^^^^^^^^ -> Cookiega malumot yozish uchun
            return "Appended";
        }

        [HttpPost]
        public string AppendToCookiesWithExpireMinute(string key, string value, int minute)
        {
            HttpContext.Response.Cookies.Append(key, value,new CookieOptions
            //                                                        ^^^^^^^^^^^^^ -> cookiega qoshilmoqchi bolgan elementga ochib ketishi uchun muddat berish uchun
            {
                Expires=DateTime.Now.AddMinutes(minute)
            });
            return "Appended";
        }
    }
}
