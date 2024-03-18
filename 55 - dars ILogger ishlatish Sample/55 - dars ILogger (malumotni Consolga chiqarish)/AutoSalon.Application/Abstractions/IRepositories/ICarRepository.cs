using AutoSalon.Application.Abstractions.IBaseRepositories;     // IBaseRepository |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                         // Car |ishlashi uchun

namespace AutoSalon.Application.Abstractions.IRepositories
{
    public interface ICarRepository:IBaseRepository<Car>
    {

    }
}
