namespace BeFit.Application.DataTransferObjects
{
    public class LoginDto
    {
        public string EmailOrPassword { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
