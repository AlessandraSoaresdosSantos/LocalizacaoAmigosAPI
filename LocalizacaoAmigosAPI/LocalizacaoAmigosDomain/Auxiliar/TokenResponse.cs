namespace LocalizacaoAmigos.Domain.Auxiliar
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }

        public TokenResponse(bool success, string message, AccessToken token)
            : base(success, message)
        {
            Token = token;
        }
    }
}
