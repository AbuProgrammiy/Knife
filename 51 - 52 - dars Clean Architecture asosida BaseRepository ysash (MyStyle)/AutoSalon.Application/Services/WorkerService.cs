using AutoSalon.Application.Abstractions.IRepositories;     // IWorkerRepository |ishlashi uchun
using AutoSalon.Application.IServices;                      // IWorkerService |ishlash uchun
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

        public string RateWorker(string workerName, double rating)
        {
            Worker worker = _workerRepository.GetByName(workerName);
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
