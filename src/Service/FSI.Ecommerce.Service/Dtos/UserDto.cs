namespace FSI.Ecommerce.Service.Dtos
{
    public class UserDto : Base
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int IdProfile { get; set; } = 0;
    }
}
