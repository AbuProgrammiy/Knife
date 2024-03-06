using AutoSalon.Application.Abstractions.IRepositories;         // IWorkerRepository |ishlashi uchun
using AutoSalon.Domain.Entities.DTOs;                           // WorkerDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                         // Worker |ishlashi uchun
using AutoSalon.Infrastructure.BaseRepositories;                // BaseRepository |ishlashi uchun
using AutoSalon.Infrastructure.Persistance;                     // AutoSalonDbContext |ishlashi uchun

namespace AutoSalon.Infrastructure.Repositories
{
    public class WorkerRepository : BaseRepository<Worker>,IWorkerRepository
    {

        public WorkerRepository(AutoSalonDbContext context):base(context)
        {
        }

        public string Create(WorkerDTO workerDTO)
        {
            Worker worker = new Worker()
            {
                Name = workerDTO.Name,
                Age = workerDTO.Age,
                Rating = workerDTO.Rating,
            };
            return Create(worker);
        }

        public string Delete(int id)
        {
            return Delete(x=>x.Id==id);
        }

        public new IEnumerable<Worker> GetAll()
        {
            return base.GetAll();
        }

        public Worker GetByName(string workerName)
        {
            return GetByAny(x=>x.Name==workerName);
        }

        public string Update(int id, WorkerDTO workerDTO)
        {
            Worker worker=GetByAny(x=>x.Id==id);
            if (worker == null)
                return "Update uchun ma'lumot topilmadi";
            worker.Name = workerDTO.Name;
            worker.Age = workerDTO.Age;
            worker.Rating = workerDTO.Rating;
            return Update(worker);
        }
    }
}
