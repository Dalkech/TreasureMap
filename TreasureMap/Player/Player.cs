using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Command;
using TreasureMap;

namespace TreasureMap
{
    public sealed class Player(string name, int x, int y, 
        Direction direction, IMap map) 
        : IPlayer
    {
        private const string displayFormat = "({0})";
        
        private readonly IMap map = map;
        private int numberOfTreasure = 0;
        private (int x, int y) coordinates = (x, y);
        private Direction direction = direction;

        public readonly string Name = name;
        public int GetNumberOfTreasure() => this.numberOfTreasure;
        public (int x, int y) GetCoordinates() => coordinates;
        public Direction Direction { get => direction; }
        public bool CanPassBy(BaseMapElement element)
            => element is not Montain or null;
        public void AddTreasure(int v)
        {
            numberOfTreasure++;
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

            #pragma warning disable CS8604 
            if (CanPassBy(element)) {
                // null case managed.
                element?.Interact(this);
                coordinates = newCoordinates;
            }
            #pragma warning restore CS8604
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
                direction switch
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
