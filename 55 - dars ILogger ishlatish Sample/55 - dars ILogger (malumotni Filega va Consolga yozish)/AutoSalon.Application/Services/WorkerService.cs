using AutoSalon.Application.Abstractions.IRepositories;     // IWorkerRepository |ishlashi uchun
using AutoSalon.Application.IServices;                      // IWorkerService |ishlash uchun
using AutoSalon.Domain.Entities.DTOs;                       // WorkerDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                     // Worker |ishlashi uchun
using Microsoft.Extensions.Logging;                         // ILogger |ishlashi uchun

namespace AutoSalon.Application.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly ILogger<WorkerService> _logger;                           // ILoggerni togri ishlatish uchun uni <> ichiga qysi Classda turganini beriladi

        public WorkerService(IWorkerRepository workerRepository, ILogger<WorkerService> logger)
        {
            _workerRepository = workerRepository;
            _logger = logger;
        }

        public string Create(WorkerDTO workerDTO)
        {
            try
            {
                Worker worker = new Worker()
                {
                    Name = workerDTO.Name,
                    Age = workerDTO.Age,
                    Rating = workerDTO.Rating,
                };

                _logger.LogInformation("Create muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _workerRepository.Create(worker);
            }
            catch
            {
                _logger.LogError("Createda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public string Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _workerRepository.Delete(x => x.Id == id);
            }
            catch
            {
                _logger.LogError("Deleteda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public new IEnumerable<Worker> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _workerRepository.GetAll();
            }
            catch
            {
                _logger.LogError("GetAllda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public Worker GetByName(string workerName)
        {
            try
            {
                _logger.LogInformation("GetByName muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _workerRepository.GetByAny(x => x.Name == workerName);
            }
            catch
            {
                _logger.LogError("GetByName xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public string Update(int id, WorkerDTO workerDTO)
        {
            try
            {

                Worker worker = _workerRepository.GetByAny(x => x.Id == id);
                if (worker == null)
                    return "Update uchun ma'lumot topilmadi";
                worker.Name = workerDTO.Name;
                worker.Age = workerDTO.Age;
                worker.Rating = workerDTO.Rating;

                _logger.LogInformation("Update muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _workerRepository.Update(worker);
            }
            catch
            {
                _logger.LogError("Updateda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public string RateWorker(string workerName, double rating)
        {
            try
            {
                Worker worker = _workerRepository.GetByAny(x=>x.Name==workerName);
                if (worker == null)
                    return "Ishchi topilmadi";
                if (rating < 1 || rating > 9)
                    return "Baho 1-9 oralig'ida bo'lishi kerak";
                worker.Rating = (worker.Rating + rating) / 2;
                _workerRepository.Update(worker);

                _logger.LogInformation("RateWorker muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return "Ishchi baholandi";
            }
            catch
            {
                _logger.LogError("RateWorker xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }
    }
}
