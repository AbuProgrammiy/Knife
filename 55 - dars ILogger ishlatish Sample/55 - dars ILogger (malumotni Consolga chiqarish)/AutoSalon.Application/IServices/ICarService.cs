using AutoSalon.Domain.Entities.DTOs;               // CarDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;             // Car |ishlashi uchun

namespace AutoSalon.Application.IServices
{
    public interface ICarService
    {
        public string Create(CarDTO carDTO);
        public IEnumerable<Car> GetAll();
        public Car GetByName(string carName);
        public string Update(int id, CarDTO carDTO);
        public string Delete(int id);
        public string RateCar(string carName, double rating);
    }
}
