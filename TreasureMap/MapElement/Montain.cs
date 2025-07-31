using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public sealed class Montain(int x, int y) : BaseMapElement('M', x, y)
    {
        public override void Interact(IPlayer player)
        {
            return;
        }
    }
}
