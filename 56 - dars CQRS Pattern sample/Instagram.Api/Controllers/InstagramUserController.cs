using Instagram.Application.UseCases.InstagramUser.Commands;                // CreateUserCommand |ishalshi uchun
using Instagram.Application.UseCases.InstagramUser.Queries;                 // GetAllUsersQuery |islashi uchun
using Instagram.Domain.Entities;                                            // User |ishlashi uchun
using MediatR;                                                              // IMediator |ishlashi uchun
using Microsoft.AspNetCore.Mvc;                                             // ControllerBase |ishlashi uchun
    
namespace Instagram.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstagramUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InstagramUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<string> Create(CreateUserCommand request)
        {
            return _mediator.Send(request);
        }

        [HttpGet]
        public Task<IEnumerable<User>> GetAll()
        {
            return _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet]
        public Task<User> GetById(int id)
        {
            return _mediator.Send(new GetByIdUserQuery { Id = id });
        }

        [HttpPut]
        public Task<string> Update(UpdateUserCommand request)
        {
            return _mediator.Send(request);
        }

        [HttpDelete]
        public Task<string> DeleteById(DeleteUserCommand command)
        {
            return _mediator.Send(command);
        }
    }
}
