using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap.Command
{
    public abstract class BasePlayerCommand(IPlayer player)
    {
        protected IPlayer _player = player; 
    }
}
