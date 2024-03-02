using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domen.Entities.Models; //User model ishlashi uchun


namespace Project.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(User user);

    }
}
