using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public sealed class Map
    {
        const char 
            MapElementSeparator = '-',
            MapEmptyElementChar = ' ';

        private int x;
        private int y;
        private MapElement[,] mapElements;

        internal Map(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.mapElements = new MapElement[x,y];
        }

        public static Map Create(int x, int y)
        {
            return new Map(x, y);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if(j > 0)
                        stringBuilder.Append(MapElementSeparator);

                    stringBuilder
                        .Append(
                            mapElements[i, j] is null ? MapEmptyElementChar
                                                      : mapElements[i, j].ToString());
                }                
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
                    
    }
}
