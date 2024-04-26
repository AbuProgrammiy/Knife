namespace Microsoft_Identity_Sample.Models
{
    public class RegisterDTO
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
