using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LineData
{
    public record BaseLineData(int x, int y)
    {
        protected int x; 
        protected int y;
    }
}
