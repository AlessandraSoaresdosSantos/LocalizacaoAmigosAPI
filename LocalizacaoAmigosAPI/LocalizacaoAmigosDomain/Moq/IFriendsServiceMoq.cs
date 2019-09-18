namespace LocalizacaoAmigos.Domain.Moq
{
    using LocalizacaoAmigos.Domain.Entities;
    using System.Collections.Generic;

    
    public interface IFriendsServiceMoq
    {
        IList<Friend> GetFriends(int latitude, int longitude);

        List<Friend> GetAllFriends();
    }
}
