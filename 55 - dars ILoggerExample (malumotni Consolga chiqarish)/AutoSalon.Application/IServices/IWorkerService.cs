using AutoSalon.Domain.Entities.DTOs;               // WorkerDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;             // Worker |ishlashi uchun

namespace AutoSalon.Application.IServices
{
    public interface IWorkerService
    {
        public string Create(WorkerDTO workerDTO);
        public IEnumerable<Worker> GetAll();
        public Worker GetByName(string workerName);
        public string Update(int id, WorkerDTO workerDTO);
        public string Delete(int id);
        public string RateWorker(string workerName, double rating);
    }
}
