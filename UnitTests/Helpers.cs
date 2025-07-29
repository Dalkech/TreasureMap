using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace UnitTests
{
    internal class Helpers
    {
        public static Player GetMockedPlayer(string name)
        => new(name, 1, 1, Direction.North, new Map(3, 3));

        public static Player GetMockedPlayer(Direction direction, int x, int y, Map map)
        => new("toto", x, y, direction, map);
    }
}
