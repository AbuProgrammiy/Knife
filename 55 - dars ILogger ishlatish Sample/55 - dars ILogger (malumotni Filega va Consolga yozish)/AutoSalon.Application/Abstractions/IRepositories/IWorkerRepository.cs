using AutoSalon.Application.Abstractions.IBaseRepositories;     // IBaseRepository |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                         // Worker |ishlashi uchun

namespace AutoSalon.Application.Abstractions.IRepositories
{
    public interface IWorkerRepository:IBaseRepository<Worker>
    {

    }
}
