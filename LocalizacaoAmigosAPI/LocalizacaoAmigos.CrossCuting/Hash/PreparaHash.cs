namespace LocalizacaoAmigos.CrossCuting.Hash
{
    public class PreparaHash
    {
        public PreparaHash() { }

        public string RetornaSenhaCriptografada(string senha)
        {
            return new Hash(System.Security.Cryptography.SHA1.Create()).Criptografar(senha);
        }
    }
}