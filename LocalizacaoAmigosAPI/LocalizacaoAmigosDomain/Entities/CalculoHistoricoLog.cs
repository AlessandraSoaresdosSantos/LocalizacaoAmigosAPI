namespace LocalizacaoAmigos.Domain.Entities
{
    using System;

    public class CalculoHistoricoLog
    {
        public int Id { get; set; }
        public DateTime DateLog { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int FriendLatitude { get; set; }
        public int FriendLongitude { get; set; }
        public double Result { get; set; }
    }
}
