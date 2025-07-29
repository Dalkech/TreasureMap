using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public sealed class Treasure(int numberOfTreasure) : BaseMapElement('T')
    {
        private const string displayFormat = "{0}({1})";
        private int numberOfTreasure = numberOfTreasure;

        public override void Interact(Player player)
        {
            if (numberOfTreasure == 0)
                return;

            numberOfTreasure--;
            player.AddTreasure(1);
        }

        public override string ToString()
        {
            if (numberOfTreasure == 0)
                return Map.MapEmptyElementChar.ToString();

            return string.Format(displayFormat, mapToken, numberOfTreasure);
        }
    }
}
