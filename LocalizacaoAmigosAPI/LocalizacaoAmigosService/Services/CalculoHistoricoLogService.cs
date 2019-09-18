namespace LocalizacaoAmigos.Service.Services
{
    using LocalizacaoAmigos.Data.Context;
    using LocalizacaoAmigos.Domain.Entities;
    using LocalizacaoAmigos.Domain.Interfaces;
    using System;

    public class CalculoHistoricoLogService : ICalculoHistoricoLogService
    {
        public void HistoricoLog(DateTime dateLog, int latitude, int longitude, int friendLatitude, int friendLongitude, double result)
        {
            using (var context = new LocalizacaoAmigosContext())
            {
                CalculoHistoricoLog calculoHistoricoLog = new CalculoHistoricoLog
                {
                    DateLog = dateLog,
                    Latitude = latitude,
                    Longitude = longitude,
                    FriendLatitude = friendLatitude,
                    FriendLongitude = friendLongitude,
                    Result = result
                };
                context.CalculoHistoricoLog.Add(calculoHistoricoLog);
                context.SaveChanges();
            }
        }
    }
}
