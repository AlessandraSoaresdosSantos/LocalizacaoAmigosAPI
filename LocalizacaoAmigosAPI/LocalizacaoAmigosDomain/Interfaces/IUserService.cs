namespace LocalizacaoAmigos.Domain.Interfaces
{
    using LocalizacaoAmigos.Domain.Auxiliar;


    public interface IUserService
    {
        TokenResponse Authenticate(string username, string password);
    }
}
