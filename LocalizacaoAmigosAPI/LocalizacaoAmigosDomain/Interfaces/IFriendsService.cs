namespace LocalizacaoAmigos.Domain.Interfaces
{
    using LocalizacaoAmigos.Domain.Entities;
    using System.Collections.Generic;

    public interface IFriendsService
    {
        IList<Friend> GetFriends(int latitude, int longitude);

        List<Friend> GetAllFriends();
    }
}
