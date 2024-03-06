using AutoSalon.Application.Abstractions.IRepositories;     // ICarRepository |ishlashi uchun
using AutoSalon.Application.IServices;                      // ICarService |ishlashi uchun
using AutoSalon.Domain.Entities.DTOs;                       // CarDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                     // Car |ishlashi uchun
using Microsoft.AspNetCore.Mvc;                             // ControllerBase |ishlashi uchun

namespace AutoSalon.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarService _carService;
        public CarController(ICarRepository carRepository,ICarService carService)
        {
            _carRepository = carRepository;
            _carService = carService;
        }

        [HttpGet]
        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        [HttpGet]
        public Car GetByName(string carName)
        {
            return _carRepository.GetByName(carName);
        }

        [HttpPost]
        public string Create(CarDTO carDTO)
        {
            return _carRepository.Create(carDTO);
        }

        [HttpPut]
        public string Update(int id,CarDTO carDTO)
        {
            return _carRepository.Update(id,carDTO);
        }

        [HttpPatch]
        public string RateCar(string carName,double rating)
        {
            return _carService.RateCar(carName,rating);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return _carRepository.Delete(id);
        }
    }
}
