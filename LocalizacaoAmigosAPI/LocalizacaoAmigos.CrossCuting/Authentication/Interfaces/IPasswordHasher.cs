namespace LocalizacaoAmigos.CrossCuting.Authentication.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
