using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    public interface IGame
    {
        Guid Id { get; }

        // TODO: This should be a custom collection that enforces rules like max players.
        ICollection<IPlayer> Players { get; }

        IPlayer Host { get; }

        IPlayer AddNewPlayer(string playerName);
    }
}
