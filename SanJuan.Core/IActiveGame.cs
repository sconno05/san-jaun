using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    public interface IActiveGame : IGame
    {
        IPlayer StartingPlayer { get; }
    }
}
