namespace LocalizacaoAmigos.CrossCuting.Authentication
{
    using LocalizacaoAmigos.CrossCuting.Authentication.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.Options;
    using System.Linq;
    using LocalizacaoAmigos.Domain.Entities;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using LocalizacaoAmigos.Domain.Auxiliar;

    public class TokenHandler : ITokenHandler
    {
        private readonly static ISet<RefreshToken> _refreshTokens = new HashSet<RefreshToken>();
        private readonly TokenOptions _tokenOptions;
        private readonly SigninConfigurations _signingConfigurations;
        private readonly IPasswordHasher _passwordHasher;


        public TokenHandler(IOptions<TokenOptions> tokenOptionsSnapshot,
            SigninConfigurations signingConfigurations,
            IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _tokenOptions = tokenOptionsSnapshot.Value;
            _signingConfigurations = signingConfigurations;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var refreshToken = BuildRefreshToken(user);
            var accessToken = BuildAccessToken(user, refreshToken);
            _refreshTokens.Add(refreshToken);

            return accessToken;
        }

        public RefreshToken GetRefreshToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;

            var refreshToken = _refreshTokens.SingleOrDefault(t => t.Token == token);
            if (refreshToken != null)
                _refreshTokens.Remove(refreshToken);

            return refreshToken;
        }

        public void RevokeRefreshToken(string token)
        {
            GetRefreshToken(token);
        }

        private RefreshToken BuildRefreshToken(User user)
        {
            var refreshToken = new RefreshToken
                (
                    token: _passwordHasher.HashPassword(Guid.NewGuid().ToString()),
                    expiration: DateTime.Now.AddSeconds(_tokenOptions.RefreshTokenExpiration).Ticks
                );

            return refreshToken;
        }

        private AccessToken BuildAccessToken(User user, RefreshToken refreshToken)
        {
            var accessTokenExpiration = DateTime.Now.AddSeconds(_tokenOptions.AccessTokenExpiration);

            var securityToken = new JwtSecurityToken
                (
                    issuer: _tokenOptions.Issuer,
                    audience: _tokenOptions.Audience,
                    claims: GetClaims(user),
                    expires: accessTokenExpiration,
                    notBefore: DateTime.Now,
                    signingCredentials: _signingConfigurations.SigningCredentials
                    
                );

            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.WriteToken(securityToken);

            return new AccessToken(accessToken, accessTokenExpiration.Ticks, refreshToken);
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Username)
            };



            return claims;
        }
    }
}
