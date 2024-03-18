using AutoSalon.Application.Abstractions.IRepositories;         // IWorkerRepository |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                         // Worker |ishlashi uchun
using AutoSalon.Infrastructure.BaseRepositories;                // BaseRepository |ishlashi uchun
using AutoSalon.Infrastructure.Persistance;                     // AutoSalonDbContext |ishlashi uchun

namespace AutoSalon.Infrastructure.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>,IWorkerRepository
    {
        // CRUD amallari Repositoryga yozilmasdan Servicega yozilganini sababi: Controllerda faqat Servicega murojat qilinishi kerak, bu Clean Architecture qoidasidir
        public WorkerRepository(AutoSalonDbContext context):base(context)
        {
        }
    }
}
