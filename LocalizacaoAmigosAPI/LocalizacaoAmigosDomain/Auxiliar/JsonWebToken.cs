namespace LocalizacaoAmigos.Domain.Auxiliar
{
    using System;
  

    public abstract class JsonWebToken
    {
        public string Token { get; private set; }
        public long Expiration { get; private set; }

        public JsonWebToken(string token, long expiration)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException();

            if (expiration <= 0)
                throw new ArgumentException();

            Token = token;
            Expiration = expiration;
        }

        public bool IsExpired()
        {
            return DateTime.Now.Ticks > Expiration;
        }
    }
}
