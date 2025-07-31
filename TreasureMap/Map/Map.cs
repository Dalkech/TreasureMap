using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace TreasureMap
{
    public sealed class Map(int width, int heigth) : IMap
    {
        public const char MapEmptyElementChar = '.';
        const string MapElementSeparator = "\t\t";

        private readonly int width  = width;
        private readonly int heigth = heigth;
        
        private readonly BaseMapElement[,] map = new BaseMapElement[width, heigth];
        private readonly List<IPlayer> players = [];  

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
        public BaseMapElement? GetMapElement(int x, int y) => map[x, y];
        public BaseMapElement[,] GetMap() => map;
        public void PlacePlayers(params IPlayer[] newPlayers)
        {
            for (int i = 0; i < newPlayers.Length; i++)
                this.players.Add(newPlayers[i]);
        }
        public void PlaceMapElements(params BaseMapElement[] newElements)
        {
            for (int i = 0; i < newElements.Length; i++)
            {
                BaseMapElement newElement = newElements[i]; 
                map[newElement.Coordinates.x,newElement.Coordinates.y] = newElement;
            }
        }
        public bool PositionIsValid(int x, int y)
            => ((0 <= x && x < width)
                && (0 <= y && y < heigth)
                && (players.FirstOrDefault(p => p.GetCoordinates() == (x, y)) is null));
    }
}
