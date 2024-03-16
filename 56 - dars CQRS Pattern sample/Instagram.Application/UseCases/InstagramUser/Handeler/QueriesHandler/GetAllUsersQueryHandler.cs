using Instagram.Application.Abstractions;                       // IApplicationDbContext |ishlashi uchun
using Instagram.Application.UseCases.InstagramUser.Queries;     // GetAllUsersQuery |ishlashi uchun
using Instagram.Domain.Entities;                                // User |ishlashi uchun
using MediatR;                                                  // IRequestHandler |ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Handeler.QueriesHandler
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult((IEnumerable<User>)_context.Users.ToList());
        }
    }
}
