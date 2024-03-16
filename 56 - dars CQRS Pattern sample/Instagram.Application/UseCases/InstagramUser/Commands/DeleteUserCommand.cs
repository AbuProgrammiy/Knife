using MediatR;                  // IRequest |ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Commands
{
    public class DeleteUserCommand:IRequest<string>
    {
        public int Id { get; set; }
    }
}
