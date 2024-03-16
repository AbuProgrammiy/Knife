using Instagram.Application.Abstractions;                       // IApplicationDbContext |ishlashi uchun
using Instagram.Application.UseCases.InstagramUser.Queries;     // GetByIdUserQuery |ishlashi uchun
using Instagram.Domain.Entities;                                // User |ishlashi uchun
using MediatR;                                                  // IRequestHandler |ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Handeler.QueriesHandler
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, User>
    {
        private readonly IApplicationDbContext _context;

        public GetByIdUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<User> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Users.FirstOrDefault(x => x.Id == request.Id))!;
        }
    }
}
