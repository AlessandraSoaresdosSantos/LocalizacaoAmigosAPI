namespace LocalizacaoAmigosService.Services
{
    using FluentValidation;
    using LocalizacaoAmigos.CrossCuting.Authentication;
    using LocalizacaoAmigos.CrossCuting.Hash;
    using LocalizacaoAmigos.Data.Context;
    using LocalizacaoAmigos.Domain.Auxiliar;
    using LocalizacaoAmigos.Domain.Entities;
    using LocalizacaoAmigos.Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class UserServices : IUserService
    {
        private readonly ITokenHandler _tokenHandler;

        public UserServices(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }
         
        private LocalizacaoAmigosContext _context = new LocalizacaoAmigosContext();
        private PreparaHash _preparaHash = new PreparaHash();

        public PreparaHash PreparaHash { get => _preparaHash; set => _preparaHash = value; }
         
        public TokenResponse Authenticate(string username, string password)
        {
            string _passwordCript = PreparaHash.RetornaSenhaCriptografada(password);

            User user = _context.Users.AsQueryable().Where(x => x.Username == username && x.Password == _passwordCript).FirstOrDefault();
             
            if (user == null)
                return new TokenResponse(false, null, null);

            var token = _tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, null, token);

        }
    }
}