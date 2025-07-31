using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Command
{
    public sealed class TurnCommand(IPlayer player, char turnSide) : BasePlayerCommand(player), IPlayerCommand
    {
        private char turnAction = turnSide;
        public void Execute()
        {
            _player.ChangeOrientation(turnAction);
        }
    }
}
