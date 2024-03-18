using AutoSalon.Application.Abstractions.IRepositories;         // IWorkerRepository |ishlashi uchun
using AutoSalon.Application.IServices;                          // IWorkerService |ishlashi uchun
using AutoSalon.Domain.Entities.DTOs;                           // WorkerDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                         // Worker |ishlashi uchun
using Microsoft.AspNetCore.Mvc;                                 // ControllerBase |ishlashi uchun

namespace AutoSalon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public IEnumerable<Worker> GetAll()
        {
            return _workerService.GetAll();
        }

        [HttpGet]
        public Worker GetByName(string workerName)
        {
            return _workerService.GetByName(workerName);
        }

        [HttpPost]
        public string Create(WorkerDTO workerDTO)
        {
            return _workerService.Create(workerDTO);
        }

        [HttpPut]
        public string Update(int id,WorkerDTO workerDTO)
        {
            return _workerService.Update(id, workerDTO);
        }

        [HttpPatch]
        public string RateWorker(string workerName,double rating)
        {
            return _workerService.RateWorker(workerName,rating);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return _workerService.Delete(id);
        }
    }
}
