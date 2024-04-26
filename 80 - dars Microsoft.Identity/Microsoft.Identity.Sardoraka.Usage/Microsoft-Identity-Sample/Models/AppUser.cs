using Microsoft.AspNetCore.Identity;                        // IdentityUser |ishlashi uchun

namespace Microsoft_Identity_Sample.Models
{
    public class AppUser:IdentityUser, IAuditable
    //                   ^^^^^^^^^^^^ -> Defult holatda eng ko'p ishlatiladigan propertylarni o'z ichiga oladi (id, username, password ... )      
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ModifedDate { get; set; }//                ^^^^^^ -> Doim Uctda bo'lishi kerak data time
        public DateTimeOffset DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
