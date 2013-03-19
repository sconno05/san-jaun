using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    internal class Player : IPlayer
    {
        public Player(Guid playerId)
        {
            this.Id = playerId;
        }

        #region IPlayer Members

        public Guid Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            set;
        }

        #endregion
    }
}
