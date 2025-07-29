using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Command
{
    public sealed class TurnCommand(Player player, char turnSide) : BasePlayerCommand(player), ICommand
    {
        private char turnAction = turnSide;
        public void Execute()
        {
            _player.ChangeOrientation(turnAction);
        }
    }
}
