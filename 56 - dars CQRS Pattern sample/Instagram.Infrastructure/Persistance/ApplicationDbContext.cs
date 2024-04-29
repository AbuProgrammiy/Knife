using Instagram.Application.Abstractions;           // IApplicationDbContext |ishlashi uchun
using Instagram.Domain.Entities;                    // User |ishlashi uchun
using Microsoft.EntityFrameworkCore;                // DbContext, DbContextOptions, DbSet |ishlashi uchun

namespace Instagram.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get; set;}

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
