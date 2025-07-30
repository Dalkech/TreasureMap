using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Command;

namespace TreasureMap
{
    public sealed class Player(string name, int x, int y, 
        Direction direction, IMap map) 
        : IDisplayable, IPlayer
    {
        private const string displayFormat = "({0})";
        
        private readonly string Name = name;
        private readonly IMap map = map;
        
        private int numberOfTreasure = 0;
        private (int x, int y) coordinates = (x, y);
        private Direction direction = direction;

        public (int x, int y) GetCoordinates() => this.coordinates;
        public Direction Direction { get => this.direction; }
        public override string ToString()
        {
            return string.Format(displayFormat, Name);
        }
        public bool CanPassBy(BaseMapElement element)
            => (element is not Montain or null);
        public void AddTreasure(int v)
        {
            this.numberOfTreasure++;
        }
        public void Move(int v)
        {
            (int x, int y) newCoordinates = direction switch
            {
                Direction.North => (coordinates.x, coordinates.y - v),
                Direction.South => (coordinates.x, coordinates.y + v),
                Direction.East => (coordinates.x + v, coordinates.y),
                Direction.West => (coordinates.x - v, coordinates.y),
                _ => coordinates
            };

            if (!map.PositionIsValid(newCoordinates.x, newCoordinates.y))
                return;

            var element = map.GetMapElement(newCoordinates.x, newCoordinates.y);

            if (CanPassBy(element)) { 
                element?.Interact(this);
                coordinates = newCoordinates;
            }
        }
        public void ChangeOrientation(char turnAction)
        {
            switch (turnAction)
            {
                case 'D': TurnRight(); break;
                case 'G': TurnLeft(); break;
                default:
                    break;
            }
        }
        private void TurnRight()
        {
            direction =
                this.direction switch
                {
                    Direction.North => Direction.East,
                    Direction.East => Direction.South,
                    Direction.South => Direction.West,
                    Direction.West => Direction.North,
                    _ => direction,
                };
        }
        private void TurnLeft()
        {
            direction =
               direction switch
               {
                   Direction.North => Direction.West,
                   Direction.West => Direction.South,
                   Direction.South => Direction.East,
                   Direction.East => Direction.North,
                   _ => direction,
               };
        }
    }
}
