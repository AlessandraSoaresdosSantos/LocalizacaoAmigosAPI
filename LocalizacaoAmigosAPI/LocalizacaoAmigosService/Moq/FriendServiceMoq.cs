namespace LocalizacaoAmigos.Service.Moq
{
    using LocalizacaoAmigos.Domain.Auxiliar;
    using LocalizacaoAmigos.Domain.Entities;
    using LocalizacaoAmigos.Domain.Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
     
    public class FriendServiceMoq: IFriendsServiceMoq
    {
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
            }

            return friends.OrderBy(x => x.Name).Take(3).ToList();

        }

        public List<Friend> GetAllFriends()
        {
            List<Friend> friends = new List<Friend>();

            friends.Add(new Friend { Id = 1, Name = "Marcos", Latitude = 4, Longitude = 9, Distance = null });
            friends.Add(new Friend { Id = 2, Name = "Patricia", Latitude = 32, Longitude = 14, Distance = null });
            friends.Add(new Friend { Id = 3, Name = "Paulo", Latitude = 11, Longitude = 44, Distance = null });
            friends.Add(new Friend { Id = 4, Name = "Melissa", Latitude = 3, Longitude = 9, Distance = null });
            friends.Add(new Friend { Id = 5, Name = "Tais", Latitude = 12, Longitude = 14, Distance = null });

            return friends;
        }
    }
}
