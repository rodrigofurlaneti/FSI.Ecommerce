namespace FSI.Ecommerce.Domain.Entities
{
    public class AuthenticationEntity
    {
        public virtual string Username { get; set; } = string.Empty;
        public virtual string Password { get; set; } = string.Empty;
        public virtual bool IsAuthentication { get; set; }
        public virtual DateTime Expiration { get; set; }
    }
}
