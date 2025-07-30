using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public abstract class BaseMapElement(char mapToken, int x, int y) : IDisplayable
    {
        protected char mapToken = mapToken;
        private (int x, int y) coordinates = (x, y);
        public (int x, int y) Coordinates { get => coordinates; } 

        public override string ToString() {
            return mapToken.ToString();
        }
        public abstract void Interact(Player player);
    }
}
