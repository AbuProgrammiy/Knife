using AutoSalon.Application.Abstractions.IRepositories;     // ICarRepository |ishalshi uchun
using AutoSalon.Application.IServices;                      // ICarService |ishlashi uchun
using AutoSalon.Domain.Entities.DTOs;                       // CarDTO |ishlashi uchun
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

        public string Create(CarDTO carDTO)
        {
            Car car = new Car()
            {
                CarName = carDTO.CarName,
                BrandName = carDTO.BrandName,
                Price = carDTO.Price,
                Rating = carDTO.Rating,
            };
            return _carRepository.Create(car);
        }

        public new IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public Car GetByName(string carName)
        {
            return _carRepository.GetByAny(x => x.CarName == carName);
        }

        public string Update(int id, CarDTO carDTO)
        {
            Car model = _carRepository.GetByAny(x => x.Id == id);
            if (model == null)
                return "Update uchun ma'lumot topilmadi";
            model.Id = id;
            model.CarName = carDTO.CarName;
            model.BrandName = carDTO.BrandName;
            model.Price = carDTO.Price;
            model.Rating = carDTO.Rating;
            return _carRepository.Update(model);
        }

        public string Delete(int id)
        {
            return _carRepository.Delete(car => car.Id == id);
        }

        public string RateCar(string carName, double rating)
        {
            Car car = _carRepository.GetByAny(x=>x.CarName==carName);
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
