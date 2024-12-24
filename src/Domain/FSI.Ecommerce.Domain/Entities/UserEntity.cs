namespace FSI.Ecommerce.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
