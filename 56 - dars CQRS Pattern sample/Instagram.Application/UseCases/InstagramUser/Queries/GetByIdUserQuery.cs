using Instagram.Domain.Entities;                // User |ishlashi uchun
using MediatR;                                  // IRequest |ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Queries
{
    public class GetByIdUserQuery:IRequest<User>
    {
        public int Id { get; set; }
    }
}
