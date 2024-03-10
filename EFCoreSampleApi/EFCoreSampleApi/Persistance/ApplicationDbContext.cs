using EFCoreSampleApi.Entities.Models;           // Persons |ishlashi uchun
using Microsoft.EntityFrameworkCore;

namespace EFCoreSampleApi.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context)
            : base(context)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
