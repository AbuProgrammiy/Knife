using AutoSalon.Application.Abstractions.IRepositories;     // ICarRepository |ishalshi uchun
using AutoSalon.Application.IServices;                      // ICarService |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                     // Car |ishlashi uchun 

namespace AutoSalon.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public string RateCar(string carName, double rating)
        {
            Car car = _carRepository.GetByName(carName);
            if (car == null)
                return "Mashina topilmadi";
            if (rating < 1 || rating > 9)
                return "Baho 1-9 oralig'ida bo'lishi kerak";
            car.Rating = (car.Rating + rating)/2;
            _carRepository.Update(car);
            return "Mashina baholandi";
        }
    }
}
