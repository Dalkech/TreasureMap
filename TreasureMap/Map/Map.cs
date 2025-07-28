using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public sealed class Map(int x, int y)
    {
        const char MapEmptyElementChar = '.';
        const string MapElementSeparator = "\t\t";

        private int x = x;
        private int y = y;
        private MapElement[,] map = new MapElement[x, y];

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if(j > 0)
                        stringBuilder.Append(MapElementSeparator);
                    
                    stringBuilder
                        .Append(
                            map[j,i] is null ? MapEmptyElementChar
                                                     : map[i,j].ToString());
                }                
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
