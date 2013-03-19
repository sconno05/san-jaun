using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    public interface IGameStateRepository
    {
        void Save(IGame game);

        IGame Load(Guid gameId);

        ICollection<IGame> GetGames();
    }
}
