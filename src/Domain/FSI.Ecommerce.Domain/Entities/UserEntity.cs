namespace FSI.Ecommerce.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public int IdProfile { get; set; } = 0;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
