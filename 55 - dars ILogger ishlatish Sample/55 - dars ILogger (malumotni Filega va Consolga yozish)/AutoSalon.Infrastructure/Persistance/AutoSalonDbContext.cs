using AutoSalon.Domain.Entities.Models;         // Car, Worker ishlashi uchun
using Microsoft.EntityFrameworkCore;            // DbContext ishlashi uchun

namespace AutoSalon.Infrastructure.Persistance
{
    public class AutoSalonDbContext:DbContext
    {
        public AutoSalonDbContext(DbContextOptions<AutoSalonDbContext> options):base(options)  
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}
