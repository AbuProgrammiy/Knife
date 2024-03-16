using Instagram.Domain.Entities;            // User |ishlashi uchun 
using MediatR;                              // IRequest |ishlashi uchun
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Application.UseCases.InstagramUser.Queries
{
    public class GetAllUsersQuery:IRequest<IEnumerable<User>>
    {
    }
}
