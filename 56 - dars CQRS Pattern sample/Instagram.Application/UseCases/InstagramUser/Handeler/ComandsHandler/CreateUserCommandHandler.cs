using Instagram.Application.Abstractions;                           // IApplicationDbContext |ishlashi uchun
using Instagram.Application.UseCases.InstagramUser.Commands;        // CreateUserCommand |ishlashi uchun
using Instagram.Domain.Entities;                                    // User |ishlashi uchun
using Mapster;                                                      // Adapt |ishlashi uchun
using MediatR;                                                      // IRequestHandler|ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Handeler.ComandsHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = request.Adapt<User>();
            _context.Users.Add(user);
            _context.SaveChangesAsync(cancellationToken);
            return Task.FromResult("201: Created");
        }
    }
}
