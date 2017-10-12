using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AtomicArcade.Services;
using Services;

namespace AtomicArcade.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        [TestMethod]
        public void TestGamesService_GetAllGames()
        {
            var gameService = new GameService();
            var games = gameService.GetAllGames();

            Assert.AreEqual(games[0].Name, "Go Fish");

        }

        [TestMethod]
        public void TestGamesService_GetFeaturedGames()
        {
            var gameService = new GameService();
            var games = gameService.GetFeaturedGames();

            Assert.AreEqual(games[0].Graphic400x200, "graphic.png");

        }

        [TestMethod]
        public void TestGamesService_GetThumbnailGames()
        {
            var gameService = new GameService();
            var games = gameService.GetThumbnailGames();

            Assert.AreEqual(games[0].Graphic100x100, "graphic.png");

        }

        [TestMethod]
        public void TestGamesService_GetDetailsGames()
        {
            var gameService = new GameService();
            var games = gameService.GetDetailsGames();

            Assert.AreEqual(games[0].TechNotes, "test");

        }

    }
}
