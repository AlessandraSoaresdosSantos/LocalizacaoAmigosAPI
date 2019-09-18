namespace LocalizacaoAmigos.CrossCuting.Authentication
{
    using LocalizacaoAmigos.Domain.Auxiliar;
    using LocalizacaoAmigos.Domain.Entities;
    

    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        RefreshToken GetRefreshToken(string token);
        void RevokeRefreshToken(string token);
    }
}
