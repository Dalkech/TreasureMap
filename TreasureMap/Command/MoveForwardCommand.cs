using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Command
{
    public sealed class MoveForwardCommand(IPlayer player) : BasePlayerCommand(player), IPlayerCommand
    {
        public void Execute() => _player.Move(1);
    }
}
