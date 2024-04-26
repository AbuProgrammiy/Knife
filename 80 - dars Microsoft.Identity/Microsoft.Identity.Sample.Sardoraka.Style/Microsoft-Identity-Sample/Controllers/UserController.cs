using Microsoft.AspNetCore.Identity;                                        // UserManager |ishlashi uchun
using Microsoft.AspNetCore.Mvc;                                             // ApiController, ControllerBase |ishlashi uchun
using Microsoft_Identity_Sample.Models;                                     // AppUser |ishlashi uchun

namespace Microsoft_Identity_Sample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        //                           ^^^^^^^ -> typesiga berilayotgan model IdentityUserni vorisi bo'lishi kerak
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public IdentityResult RegisterDTO(RegisterDTO registerDTO)
        {
            AppUser appUser = new AppUser
            {
                Age = registerDTO.Age,
                Gender = registerDTO.Gender,
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
            };

            IdentityResult resultOfCreation = _userManager.CreateAsync(appUser, registerDTO.Password).Result;
            //                                             ^^^^^^^^^^^ -> user create qilish
            if (!resultOfCreation.Succeeded)
                return resultOfCreation;

            IdentityResult resultOfRoles = _userManager.AddToRolesAsync(appUser, registerDTO.Roles).Result;
            //                                          ^^^^^^^^^^^^^^^ -> mavjud userga rollarni biriktirish

            return resultOfRoles;
        }

        [HttpPost]
        public Microsoft.AspNetCore.Identity.SignInResult LogIn(LoginDTO loginDTO)
        {
            AppUser appUser;
            try/*
            ^^^ ->  FindByEmailAsync email topilmasa null orniga exseption qaytaradi shuning uchun try&catch ishlatildi*/
            {
                appUser = _userManager.FindByEmailAsync(loginDTO.Email).Result;
            }
            catch
            {
                throw new Exception("Email Not Found");
            }


            Microsoft.AspNetCore.Identity.SignInResult result=_signInManager.PasswordSignInAsync(appUser,loginDTO.Password,isPersistent:true,lockoutOnFailure:false).Result;
            /*                                                               ^^^^^^^^^^^^^^^^^^^                           ^^^^^^^^^^^^      ^^^^^^^^^^^^^^^^ -> ushbu parametrga true berilsa: user notogri password kiritsa uning accounti 30-daqiqaga bloklanadi (ushbu muddat davomida togri password kiritsa ham kira olmaydi!).
            *                                                                          |                                         |
            *                                                                          |                                         |-> ushbu parametrga true berilsa: cookiega yozilgan token browserdan chiqib ketilsa ham dastur toxtasa ham 14 kun davomida saqlanadi (agar true berilmasa browserdan chiqib ketishingiz bilan cookie tozalanadi)
            *                                                                          |
            *                                                                          |-> ushbu funksiya Passwordni togri notogriligiga tekshirib javob qaytaradi (agar Success true bolsa token generate qilib uni responseni Cookiesiga joylab qoyadi).
            */

            if (result.Succeeded)
                return result;
            else
                throw new Exception("Password is incorrect!");
        }

        [HttpPost]
        public IdentityResult WriteTokenToDatabase(string email,string tokenName,string tokenValue)
        {
            AppUser user= _userManager.FindByEmailAsync(email).Result;
            IdentityResult result=_userManager.SetAuthenticationTokenAsync(user, loginProvider: "Google", tokenName, tokenValue).Result;
            //                                                                   ^^^^^^^^^^^^^ -> ushbu propertyga externalLoginProvider beriladi masalan: "Google", "Facebook"
            return result;
        }

        [HttpGet]
        public IEnumerable<AppUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        [HttpPost]
        public IdentityResult CreateRole(IdentityRole identityRole)
        {
            return _roleManager.CreateAsync(identityRole).Result;
        }
    }
}
