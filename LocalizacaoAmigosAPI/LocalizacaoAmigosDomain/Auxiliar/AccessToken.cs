﻿namespace LocalizacaoAmigos.Domain.Auxiliar
{
    using System;


    public class AccessToken : JsonWebToken
    {
        public RefreshToken RefreshToken { get; private set; }

        public AccessToken(string token, long expiration, RefreshToken refreshToken)
            : base(token, expiration)
        {
            RefreshToken = refreshToken ?? throw new ArgumentException("Especifique um refresh token válido.");
        }
    }
}
