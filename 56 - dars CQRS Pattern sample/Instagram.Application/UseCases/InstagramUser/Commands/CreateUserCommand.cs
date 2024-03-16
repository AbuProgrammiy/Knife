using MediatR;                                      // IRequest |ishlashi uchun

namespace Instagram.Application.UseCases.InstagramUser.Commands
{
    public class CreateUserCommand:IRequest<string>
    {
        public string UserName { get; set; }
        public string Bio { get; set; }
        public int PostsCount { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string PicturePath { get; set; }
    }
}
