using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanJuan.Core
{
    public interface IPlayer
    {
        Guid Id { get; }
        string Name { get; set; }
    }
}
