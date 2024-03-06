using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalon.Application.IServices
{
    public interface ICarService
    {
        public string RateCar(string carName, double rating);
    }
}
