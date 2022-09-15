namespace DevFreela.Core.Services
{
    public interface IAuthService
    {
        string GenerateJWTToken(string email, string role);
    }
}

