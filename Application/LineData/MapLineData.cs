using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace Application.LineData
{
    public record MapLineData(int width, int height) : BaseLineData(0,0)
    {
        public readonly int Width = width;
        public readonly int Height = height;

        public IMap ToMap()
        => new Map(Width,Height);
    }
}
