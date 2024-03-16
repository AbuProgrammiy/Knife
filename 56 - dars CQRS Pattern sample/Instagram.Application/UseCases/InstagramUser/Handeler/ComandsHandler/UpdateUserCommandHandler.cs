using Instagram.Application.Abstractions;                           // IApplicationDbContext |ishlashi uchun
using Instagram.Application.UseCases.InstagramUser.Commands;        // UpdateUserCommand |ishlashi uchun
using Instagram.Domain.Entities;                                    // User |ishlashi uchun
using Mapster;                                                      // Adapt |ishlashi uchun
using MediatR;                                                      // IRequestHandler |ishalshi uchun

namespace Instagram.Application.UseCases.InstagramUser.Handeler.ComandsHandler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = request.Adapt<User>();
            _context.Users.Update(user);
            _context.SaveChangesAsync(cancellationToken);
            return Task.FromResult("203: Updated");
        }
    }
}
