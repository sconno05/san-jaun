using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SanJuan.Core.Tests.Utilities;

namespace SanJuan.Core.Tests
{
    [TestClass]
    public class GameServiceTests
    {
        private IGameStateRepository _gameStateRepository;
        private GameService _gameService;

        [TestInitialize]
        public void Setup()
        {
            _gameStateRepository = new InMemoryGameStateRepository();
            _gameService = new GameService(_gameStateRepository);
        }

        [TestMethod]
        public void CreateGame()
        {
            var game = _gameService.CreateGame(TestDefaults.PLAYER_NAME_1);

            Assert.AreNotEqual(Guid.Empty, game.Id);
            Assert.IsNotNull(game.Host);
            Assert.AreEqual(TestDefaults.PLAYER_NAME_1, game.Host.Name);
        }

        [TestMethod]
        public void LoadSaveGame()
        {
            // Create a game with just a host player and save it
            var game = _gameService.CreateGame(TestDefaults.PLAYER_NAME_1);
            var player = game.Host;
            _gameService.SaveGame(game);

            // Load the game and player
            var loadedGame = _gameService.LoadGame(game.Id);
            var loadedPlayer = loadedGame.Players.First();

            // Verify the game
            Assert.IsNotNull(loadedGame);
            Assert.AreEqual(game.Id, loadedGame.Id);

            // Verify the player
            Assert.IsNotNull(loadedPlayer);
            Assert.AreEqual(player.Id, loadedPlayer.Id);
        }

        [TestMethod]
        public void GetGames()
        {
            IGame game;
            for (int i = 0; i < 10; i++)
            {
                game = _gameService.CreateGame(TestDefaults.PLAYER_NAME_1);
                _gameService.SaveGame(game);
            }

            var games = _gameService.GetGames();
            Assert.AreEqual(10, games.Count);
        }

        [TestMethod]
        public void AddNewPlayer()
        {
            var game = _gameService.CreateGame(TestDefaults.PLAYER_NAME_1);
            var player = game.AddNewPlayer(TestDefaults.PLAYER_NAME_2);
            Assert.AreNotEqual(Guid.Empty, player.Id);
            Assert.AreEqual(2, game.Players.Count);
        }
    }
}
