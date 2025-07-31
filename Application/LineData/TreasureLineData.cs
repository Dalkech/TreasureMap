using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace Application.LineData
{
    public record TreasureLineData(int numberOfTreasure, int x, int y): BaseLineData(x, y)
    {
        public int NumberOfTreasure = numberOfTreasure;

        public Treasure ToTreasure()
        => new Treasure(NumberOfTreasure, x, y);

        internal static Treasure[] ToMapElements(IReadOnlyList<TreasureLineData> models)
        {
            List<Treasure> results = [];
            foreach (var model in models)
                results.Add(model.ToTreasure());
            return [.. results];
        }
    }
}
