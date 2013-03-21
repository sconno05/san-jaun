using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    internal class Game : IGame
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

        #endregion
    }
}
