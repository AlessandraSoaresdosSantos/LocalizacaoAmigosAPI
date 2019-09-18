namespace LocalizacaoAmigosTest
{
    using LocalizacaoAmigos.Domain.Entities;
    using LocalizacaoAmigos.Domain.Interfaces;
    using LocalizacaoAmigos.Service.Moq;
    using LocalizacaoAmigos.Service.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;

    [TestClass]
    public class FriendTest
    {
        [TestMethod]
        [DataRow(4,5)]
        public void Encontrar_Amigos_Retornou_Tres_Amigos(int latitude, int longitude)
        {
            List<Friend> friends = new List<Friend>();

            Mock<IFriendsService> mock = new Mock<IFriendsService>();
            mock.Setup(_ => _.GetFriends(latitude, longitude));
            var _friendServiceMoq = new FriendServiceMoq();

            var resultado = _friendServiceMoq.GetFriends(latitude, longitude);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Count);
        }

        [TestMethod]
        [DataRow(0, 0)]
        public void Nao_Encontrou_Amigos(int latitude, int longitude)
        {
            List<Friend> friends = new List<Friend>();

            Mock<IFriendsService> mock = new Mock<IFriendsService>();
            mock.Setup(_ => _.GetFriends(latitude, longitude));
            var _friendServiceMoq = new FriendServiceMoq();

            var resultado = _friendServiceMoq.GetFriends(latitude, longitude);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(0, resultado.Count);
        }
    }
}
