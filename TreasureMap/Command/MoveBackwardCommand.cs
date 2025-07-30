using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Command
{
    public sealed class MoveBackwardCommand(IPlayer player) : BasePlayerCommand(player), ICommand
    {
        public void Execute() => _player.Move(-1);
    }
}
