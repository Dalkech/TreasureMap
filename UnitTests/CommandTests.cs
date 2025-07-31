using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;
using TreasureMap.Command;
using UnitTests.Mockup;

namespace UnitTests
{
    public class CommandTests
    {
        [Theory]
        [InlineData(Direction.North,'D',Direction.East)]
        [InlineData(Direction.East, 'D', Direction.South)]
        [InlineData(Direction.South,'D', Direction.West)]
        [InlineData(Direction.West, 'D', Direction.North)]
        [InlineData(Direction.North,'G', Direction.West)]
        [InlineData(Direction.West, 'G', Direction.South)]
        [InlineData(Direction.South,'G', Direction.East)]
        [InlineData(Direction.East, 'G', Direction.North)]
        public void Turn(Direction direction, char turnSide, Direction expected)
        {
            //arrange
            Player player = Helpers.GetPlayer(direction, 0,0, new Map(3,3));
            IPlayerCommand turnCommand = new TurnCommand(player, turnSide);
            
            //act
            turnCommand.Execute();
            Direction newDirection = player.Direction;
            
            Assert.Equal(expected, newDirection);
        }

        [Theory]
        [InlineData(Direction.North, 1,1, 1,0)]
        [InlineData(Direction.South, 1,1, 1,2)]
        [InlineData(Direction.East,  1,1, 2,1)]
        [InlineData(Direction.West,  1,1, 0,1)]
        public void Forward(
            Direction direction, 
            int x, int y, 
            int expectedX, int expectedY)
        {
            //arrange 
            Map map = new Map(10, 10);
            Player player = Helpers.GetPlayer(direction, x, y, map);
            IPlayerCommand commandForward = new MoveForwardCommand(player);

            //act
            commandForward.Execute();
            (int x, int y) newCoordinates = player.GetCoordinates();

            //assert
            Assert.Equal((expectedX, expectedY), newCoordinates);
        }

        [Theory]
        [InlineData(Direction.North, 1,1, 1,2)]
        [InlineData(Direction.South, 1,1, 1,0)]
        [InlineData(Direction.East,  1,1, 0,1)]
        [InlineData(Direction.West,  1,1, 2,1)]
        public void Backward(
            Direction direction,
            int x, int y,
            int expectedX, int expectedY)
        {
            //arrange 
            Map map = new Map(10, 10);
            Player player = Helpers.GetPlayer(direction, x, y, map);
            IPlayerCommand commandBackward = new MoveBackwardCommand(player);

            //act
            commandBackward.Execute();
            (int x, int y) newCoordinates = player.GetCoordinates();

            //assert
            Assert.Equal((expectedX, expectedY), newCoordinates);
        }
    }
}
