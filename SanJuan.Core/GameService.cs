using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    public class GameService
    {
        private readonly IGameStateRepository _gameStateRepository;

        public GameService(IGameStateRepository gameStateRepository)
        {
            _gameStateRepository = gameStateRepository;
        }

        public IGame CreateGame(string hostPlayerName)
        {
            var game = new Game(Guid.NewGuid());
            var host = game.AddNewPlayer(hostPlayerName);
            return game;
        }

        public void SaveGame(IGame game)
        {
            _gameStateRepository.Save(game);
        }

        public IGame LoadGame(Guid gameId)
        {
            return _gameStateRepository.Load(gameId);
        }

        public ICollection<IGame> GetGames()
        {
            return _gameStateRepository.GetGames();
        }
    }
}
