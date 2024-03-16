using Instagram.Application.Abstractions;                               // IApplicationDbContext |ishlashi uchun
using Instagram.Application.UseCases.InstagramUser.Commands;            // DeleteUserCommand |ishlashi uchun
using MediatR;                                                          // IRequestHandler |ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Handeler.ComandsHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _context.Users.Remove(_context.Users.FirstOrDefault(x=>x.Id==request.Id)!);
            _context.SaveChangesAsync(cancellationToken);
            return Task.FromResult("204: Deleted");
        }
    }
}
