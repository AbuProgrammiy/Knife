using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmailSenderApp.Domen.Entities.Models;
using EmailSenderApp.Application.Services;

namespace EmailSenderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;
        public EmailSenderController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        [HttpPost]
        public string SendEmail(EmailModel emailModel)
        {
            _sendEmailService.SendEmailAsync(emailModel).GetAwaiter().GetResult();
            return "Email jo'natildi";
        }
    }
}
