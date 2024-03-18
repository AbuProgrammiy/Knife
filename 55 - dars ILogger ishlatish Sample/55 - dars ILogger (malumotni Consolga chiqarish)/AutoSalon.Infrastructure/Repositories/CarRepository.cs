using AutoSalon.Application.Abstractions.IRepositories;     // ICarRepository |ishlatish uchun
using AutoSalon.Domain.Entities.Models;                     // Car |ishlashi uchun
using AutoSalon.Infrastructure.BaseRepositories;            // BaseRepository |ishlashi uchun
using AutoSalon.Infrastructure.Persistance;                 // AutoSalonDbContext |ishlashi uchun

namespace AutoSalon.Infrastructure.Repositories
{
    // CRUD amallari Repositoryga yozilmasdan Servicega yozilganini sababi: Controllerda faqat Servicega murojat qilinishi kerak, bu Clean Architecture qoidasidir
    public class CarRepository:BaseRepository<Car>,ICarRepository
    {
        public CarRepository(AutoSalonDbContext context):base(context)
        {
        }
    }
}
