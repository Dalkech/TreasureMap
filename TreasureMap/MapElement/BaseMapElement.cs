using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public abstract class BaseMapElement(char token, int x, int y)
    {
        public readonly char Token = token;
        public readonly (int x, int y) Coordinates = (x, y);
        public abstract void Interact(IPlayer player);
    }
}
