using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace Application.LineData
{
    public record MontainLineData(int x, int y) : BaseLineData(x, y)
    {
        public Montain ToMontain()
        => new Montain(x, y);

        internal static Montain[] ToMapElements(IReadOnlyList<MontainLineData> models)
        {
            List<Montain> results = [];
            foreach (var model in models)
                results.Add(model.ToMontain());
            return [.. results];
        }
    }
}
