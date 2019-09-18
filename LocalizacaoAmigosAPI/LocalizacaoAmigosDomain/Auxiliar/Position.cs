namespace LocalizacaoAmigos.Domain.Auxiliar
{
    public class Position
    {
        public Position(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Latitude { get; set; }
        public int Longitude { get; set; }
    }
}
