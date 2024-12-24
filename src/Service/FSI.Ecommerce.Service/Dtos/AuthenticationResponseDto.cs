namespace FSI.Ecommerce.Service.Dtos
{
    public class AuthenticationResponseDto
    {
        public virtual Guid Token { get; set; }
        public virtual bool IsAuthentication { get; set; }
        public virtual DateTime Expiration { get; set; }
        public virtual string Message { get; set; }
    }
}
