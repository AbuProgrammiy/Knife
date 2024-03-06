using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalon.Application.IServices
{
    public interface IWorkerService
    {
        public string RateWorker(string workerName, double rating);
    }
}
