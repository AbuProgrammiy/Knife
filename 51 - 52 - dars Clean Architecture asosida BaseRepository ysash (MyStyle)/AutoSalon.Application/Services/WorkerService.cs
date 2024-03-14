using AutoSalon.Application.Abstractions.IRepositories;     // IWorkerRepository |ishlashi uchun
using AutoSalon.Application.IServices;                      // IWorkerService |ishlash uchun
using AutoSalon.Domain.Entities.DTOs;                       // WorkerDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                     // Worker |ishlashi uchun

namespace AutoSalon.Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public string Create(WorkerDTO workerDTO)
        {
            Worker worker = new Worker()
            {
                Name = workerDTO.Name,
                Age = workerDTO.Age,
                Rating = workerDTO.Rating,
            };
            return _workerRepository.Create(worker);
        }

        public string Delete(int id)
        {
            return _workerRepository.Delete(x => x.Id == id);
        }

        public new IEnumerable<Worker> GetAll()
        {
            return _workerRepository.GetAll();
        }

        public Worker GetByName(string workerName)
        {
            return _workerRepository.GetByAny(x => x.Name == workerName);
        }

        public string Update(int id, WorkerDTO workerDTO)
        {
            Worker worker = _workerRepository.GetByAny(x => x.Id == id);
            if (worker == null)
                return "Update uchun ma'lumot topilmadi";
            worker.Name = workerDTO.Name;
            worker.Age = workerDTO.Age;
            worker.Rating = workerDTO.Rating;
            return _workerRepository.Update(worker);
        }

        public string RateWorker(string workerName, double rating)
        {
            Worker worker = _workerRepository.GetByAny(x=>x.Name==workerName);
            if (worker == null)
                return "Ishchi topilmadi";
            if (rating < 1 || rating > 9)
                return "Baho 1-9 oralig'ida bo'lishi kerak";
            worker.Rating = (worker.Rating + rating) / 2;
            _workerRepository.Update(worker);
            return "Ishchi baholandi";
        }
    }
}
