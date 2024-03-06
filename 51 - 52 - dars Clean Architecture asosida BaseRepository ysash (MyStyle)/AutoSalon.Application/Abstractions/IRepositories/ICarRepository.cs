using AutoSalon.Application.Abstractions.IBaseRepositories;     // IBaseRepository |ishlashi uchun
using AutoSalon.Domain.Entities.DTOs;
using AutoSalon.Domain.Entities.Models;                         // Car |ishlashi uchun

namespace AutoSalon.Application.Abstractions.IRepositories
{
    public interface ICarRepository:IBaseRepository<Car>
    {
        public string Create(CarDTO carDTO);
        public IEnumerable<Car> GetAll();
        public Car GetByName(string carName);
        public string Update(int id, CarDTO carDTO);
        public string Delete(int id);
    }
}
