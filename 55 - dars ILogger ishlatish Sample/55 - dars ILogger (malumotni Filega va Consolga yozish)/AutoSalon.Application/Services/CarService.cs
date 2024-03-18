using AutoSalon.Application.Abstractions.IRepositories;     // ICarRepository |ishalshi uchun
using AutoSalon.Application.IServices;                      // ICarService |ishlashi uchun
using AutoSalon.Domain.Entities.DTOs;                       // CarDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                     // Car |ishlashi uchun 
using Microsoft.Extensions.Logging;                         // ILogger |ishlashi uchun

namespace AutoSalon.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<CarService> _logger;           // ILoggerni togri ishlatish uchun uni <> ichiga qysi Classda turganini beriladi

        public CarService(ICarRepository carRepository, ILogger<CarService> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public string Create(CarDTO carDTO)
        {
            try
            {
                Car car = new Car()
                {
                    CarName = carDTO.CarName,
                    BrandName = carDTO.BrandName,
                    Price = carDTO.Price,
                    Rating = carDTO.Rating,
                };

                _logger.LogInformation("Create muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _carRepository.Create(car);
            }
            catch
            {
                _logger.LogError("Createda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
            
        }

        public new IEnumerable<Car> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _carRepository.GetAll();
            }
            catch
            {
                _logger.LogError("GetAllda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public Car GetByName(string carName)
        {
            try
            {
                _logger.LogInformation("GetByName muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _carRepository.GetByAny(x => x.CarName == carName);
            }
            catch
            {
                _logger.LogError("GetByName xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public string Update(int id, CarDTO carDTO)
        {
            try
            {
                Car model = _carRepository.GetByAny(x => x.Id == id);
                if (model == null)
                    return "Update uchun ma'lumot topilmadi";
                model.Id = id;
                model.CarName = carDTO.CarName;
                model.BrandName = carDTO.BrandName;
                model.Price = carDTO.Price;
                model.Rating = carDTO.Rating;

                _logger.LogInformation("Update muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _carRepository.Update(model);
            }
            catch
            {
                _logger.LogError("Update xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public string Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return _carRepository.Delete(car => car.Id == id);
            }
            catch
            {
                _logger.LogError("Delete xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }

        public string RateCar(string carName, double rating)
        {
            try
            {
                Car car = _carRepository.GetByAny(x=>x.CarName==carName);
                if (car == null)
                    return "Mashina topilmadi";
                if (rating < 1 || rating > 9)
                    return "Baho 1-9 oralig'ida bo'lishi kerak";
                car.Rating = (car.Rating + rating)/2;
                _carRepository.Update(car);

                _logger.LogInformation("RateCar muvaffaiyatli ishladi");    // Loggerdan kelayotgan xabarni consolega chiqaradi

                return "Mashina baholandi";
            }
            catch
            {
                _logger.LogError("RateCarda xatolik uz berdi!");           // Loggerdan kelayotgan xabarni consolega chiqaradi
                throw;
            }
        }
    }
}
