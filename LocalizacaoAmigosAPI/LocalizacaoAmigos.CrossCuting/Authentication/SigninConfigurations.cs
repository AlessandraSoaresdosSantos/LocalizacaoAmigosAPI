﻿namespace LocalizacaoAmigos.CrossCuting.Authentication
{
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Cryptography;


    public class SigninConfigurations
    {

        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigninConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
