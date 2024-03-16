using Instagram.Domain.Entities;                            // User |ishlashi uchun
using Microsoft.EntityFrameworkCore;                        // DbSet |ishlashi uchun     

namespace Instagram.Application.Abstractions
{
    public interface IApplicationDbContext
    {   
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
