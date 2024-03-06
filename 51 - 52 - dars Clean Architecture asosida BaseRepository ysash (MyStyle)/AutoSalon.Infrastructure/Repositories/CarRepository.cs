using AutoSalon.Application.Abstractions.IRepositories;     // ICarRepository |ishlatish uchun
using AutoSalon.Domain.Entities.DTOs;                       // CarDTO |ishlashi uchun
using AutoSalon.Domain.Entities.Models;                     // Car |ishlashi uchun
using AutoSalon.Infrastructure.BaseRepositories;            // BaseRepository |ishlashi uchun
using AutoSalon.Infrastructure.Persistance;                 // AutoSalonDbContext |ishlashi uchun

namespace AutoSalon.Infrastructure.Repositories
{
    public class CarRepository:BaseRepository<Car>,ICarRepository
    {
        public CarRepository(AutoSalonDbContext context):base(context)
        {
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
            return Create(car);
        }

        public new IEnumerable<Car> GetAll()
        {
            return base.GetAll();
        }

        public Car GetByName(string carName)
        {
            return GetByAny(x=>x.CarName==carName);
        }

        public string Update(int id,CarDTO carDTO)
        {
            Car model=GetByAny(x=>x.Id==id);
            if (model == null)
                return "Update uchun ma'lumot topilmadi";
            model.Id = id;
            model.CarName = carDTO.CarName;
            model.BrandName = carDTO.BrandName;
            model.Price = carDTO.Price;
            model.Rating = carDTO.Rating;
            return Update(model);
        }

        public string Delete(int id)
        {
            return Delete(car=>car.Id==id);
        }
    }
}
