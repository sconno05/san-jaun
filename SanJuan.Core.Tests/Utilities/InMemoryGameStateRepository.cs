using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core.Tests.Utilities
{
    internal class InMemoryGameStateRepository : IGameStateRepository
    {
        private readonly Dictionary<Guid, IGame> _games;

        public InMemoryGameStateRepository()
        {
            _games = new Dictionary<Guid, IGame>();
        }

        #region IGameStateRepository Members

        public void Save(IGame game)
        {
            if (game == null)
            {
                throw new ArgumentNullException("game");
            }

            if (game.Id == Guid.Empty)
            {
                throw new ArgumentException("game Id must not be empty");
            }

            _games[game.Id] = game;
        }

        public IGame Load(Guid gameId)
        {
            return _games[gameId];
        }

        public ICollection<IGame> GetGames()
        {
            return _games.Values;
        }

        #endregion
    }
}
