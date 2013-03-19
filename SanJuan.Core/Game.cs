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

        public IPlayer AddNewPlayer()
        {
            var player = new Player(Guid.NewGuid());
            this.Players.Add(player);
            return player;
        }

        #endregion
    }
}
