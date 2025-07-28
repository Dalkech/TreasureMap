using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public sealed class Map(int width, int heigth)
    {
        const char MapEmptyElementChar = '.';
        const string MapElementSeparator = "\t\t";

        private int width  = width;
        private int heigth = heigth;
        private BaseMapElement[,] map = new BaseMapElement[width, heigth];
        internal (int x, int y) playerCoordinates = (0, 0);

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < heigth; i++)
            {
                for (int j = 0; j < width; j++)
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
