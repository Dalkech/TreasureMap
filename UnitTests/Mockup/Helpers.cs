using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace UnitTests.Mockup
{
    internal class Helpers
    {
        public static Player GetPlayer(string name)
        => new(name, 1, 1, Direction.North, new Map(3, 3));

        public static Player GetPlayer(Direction direction, int x, int y, IMap map)
        => new("toto", x, y, direction, map);
    }
}
