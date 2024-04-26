using Microsoft.AspNetCore.Identity.EntityFrameworkCore;                // IdentityDbContext |ishlashi uchun
using Microsoft.EntityFrameworkCore;                                    // DbContextOptions |Ishlashi uchun            
using Microsoft_Identity_Sample.Models;                                 // AppUser |ishlashi uchun

namespace Microsoft_Identity_Sample
{
    public class ApplicationIdentityDbContext : IdentityDbContext<AppUser>
    //                                          ^^^^^^^^^^^^^^^^^ -> IdentityDbContext DbContexni o'rniga ishlatilmoqda
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            :base(options) 
        {
            Database.Migrate();
            /*       ^^^^^^^ -> Add-Migration qilinganda Update-Database qilish shart emas 
                                              (yangi databasa ochiladigan bo'lsa ishlaydi, mavjud databasani update qilinsa ishlamaydi baribibr)*/
        }
    }
}
