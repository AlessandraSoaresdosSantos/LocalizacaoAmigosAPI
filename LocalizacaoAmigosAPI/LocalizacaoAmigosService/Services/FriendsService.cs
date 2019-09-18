namespace LocalizacaoAmigos.Service.Services
{
    using FluentValidation;
    using LocalizacaoAmigos.Data.Context;
    using LocalizacaoAmigos.Domain.Auxiliar;
    using LocalizacaoAmigos.Domain.Entities;
    using LocalizacaoAmigos.Domain.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class FriendsService : IFriendsService
    {
        private LocalizacaoAmigosContext _context = new LocalizacaoAmigosContext();
        ICalculoHistoricoLogService _calculoHistoricoLogService;

        public FriendsService(ICalculoHistoricoLogService calculoHistoricoLogService)
        {
            _calculoHistoricoLogService = calculoHistoricoLogService;
        }


        public IList<Friend> GetFriends(int latitude, int longitude)
        {
            Position position = new Position(latitude, longitude);

            List<Friend> friends = GetAllFriends();

            var findFriends = CalculeDistance(position, friends);

            return findFriends;
        }

        private IList<Friend> CalculeDistance(Position position, List<Friend> friends)
        {
            foreach (var item in friends)
            {
                item.Distance = Math.Sqrt(Math.Pow(item.Latitude - position.Latitude, 2)
                    + Math.Pow(item.Longitude - position.Longitude, 2));

                System.Threading.Tasks.Task.Run(() =>
                {
                    _calculoHistoricoLogService.HistoricoLog(DateTime.Now, 
                                                             position.Latitude,
                                                             position.Longitude,
                                                             item.Latitude, item.Longitude, (double)item.Distance);
                });
            }

            return friends.OrderBy(x => x.Name).Take(3).ToList();

        }

        public List<Friend> GetAllFriends()
        {

            return _context.Friends.ToList();
        }

        private void Validate(Friend obj, AbstractValidator<Friend> validator)
        {
            if (obj == null)
                throw new Exception("Registros não localizados.");

            validator.ValidateAndThrow(obj);
        }
    }
}