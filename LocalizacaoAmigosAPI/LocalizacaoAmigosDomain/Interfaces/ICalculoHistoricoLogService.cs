using System;

namespace LocalizacaoAmigos.Domain.Interfaces
{
    public interface ICalculoHistoricoLogService
    {
        void HistoricoLog(DateTime dateLog, int latitude, int longitude, int friendLatitude, int friendLongitude, double result);
    }
}
