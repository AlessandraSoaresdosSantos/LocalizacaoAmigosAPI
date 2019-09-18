namespace LocalizacaoAmigos.Domain.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public double? Distance { get; set; }
    }
}
