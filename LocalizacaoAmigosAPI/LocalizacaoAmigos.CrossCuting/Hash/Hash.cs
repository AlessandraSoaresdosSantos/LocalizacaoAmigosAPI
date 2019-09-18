namespace LocalizacaoAmigos.CrossCuting.Hash
{
    using System.Security.Cryptography;
    using System.Text;


    public class Hash
    {
        private HashAlgorithm _hash;

        public Hash(HashAlgorithm algoritmo)
        {
            _hash = algoritmo;
        }

        public string Criptografar(string senha)
        {
            var valor = Encoding.UTF8.GetBytes(senha);
            var password = _hash.ComputeHash(valor);

            var sb = new StringBuilder();
            foreach (var value in password)
            {
                sb.Append(value.ToString("X2"));
            }

            return sb.ToString();
        }

        public bool Verificar(string senha, string senhaCadastrada)
        {
            var password = _hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            var sb = new StringBuilder();
            foreach (var value in password)
            {
                sb.Append(value.ToString("X2"));
            }

            return sb.ToString() == senhaCadastrada;
        }
          
    }
}