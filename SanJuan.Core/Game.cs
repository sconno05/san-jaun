using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    internal class Game : IGame, IActiveGame
    {
        public Game(Guid id)
        {
            this.Id = id;
        }

        #region IGame Members

        public Guid Id
        {
            get;
            private set;
        }

        public IPlayer Host
        {
            get;
            private set;
        }

        private List<IPlayer> _players;
        public ICollection<IPlayer> Players
        {
            get
            {
                if (_players == null)
                {
                    _players = new List<IPlayer>();
                }

                return _players;
            }
        }

        public IPlayer AddNewPlayer(string playerName)
        {
            // TODO: handle duplicate player names
            var player = new Player(Guid.NewGuid(), playerName);
            this.Players.Add(player);

            if (this.Players.Count == 1)
            {
                this.Host = player;
            }

            return player;
        }

        public IActiveGame Start()
        {
            // TODO: Move these to constants or static somewhere.
            if (this.Players.Count < 2 || this.Players.Count > 4)
            {
                throw new InvalidOperationException("A game can only be started when there are 2-4 players");
            }

            var random = new Random();
            int next = random.Next(0, this.Players.Count - 1);
            this.StartingPlayer = this.Players.ElementAt(next);

            return this as IActiveGame;
        }

        #endregion

        #region IActiveGame Members

        public IPlayer StartingPlayer
        {
            get;
            private set;
        }

        #endregion
    }
}
