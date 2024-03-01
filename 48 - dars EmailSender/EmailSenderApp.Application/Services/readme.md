## html code jo'natish uchun code shu holda o'zgartiriladi vvv

string path = @"D:\sms.html";

using (var stream = new StreamReader(path))
{
    emailModel.Body = await stream.ReadToEndAsync();
}
IConfigurationSection? emailSettings = _config.GetSection("EmailSettings");
MailMessage? mailMessage = new MailMessage
{
    From = new MailAddress(emailSettings["Sender"]!, emailSettings["SenderName"]),
    Subject = emailModel.Subject,
    Body = emailModel.Body,
    IsBodyHtml = true,

};