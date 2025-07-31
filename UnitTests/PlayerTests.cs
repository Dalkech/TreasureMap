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
    public class PlayerTests
    {

        [Fact]
        public void ShouldNotPassOnMontain()
        {
            //arrange
            IMap map = new Map(3, 3);
            map.PlaceMapElements(new Montain(1, 0));
            Player player = Helpers.GetPlayer(Direction.North, 1, 1, map);
            //act
            IPlayerCommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            //assert
            Assert.Equal((1, 1), player.GetCoordinates());
        }

        [Fact]
        public void ShouldNotPassOnOtherPlayer()
        {
            //arrange
            IMap map = new Map(3, 3);
            Player player = Helpers.GetPlayer(Direction.North, 1,1, map);
            Player obstaclePlayer = Helpers.GetPlayer(Direction.North, 1, 0, map);
            map.PlacePlayers(obstaclePlayer);
            //act
            IPlayerCommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            //assert
            Assert.Equal( (1,1), player.GetCoordinates());
        }

        [Fact]
        public void ShouldPassOnTreasure()
        {
            //arrange
            IMap map = new Map(3, 3);
            Treasure treasure = new Treasure(1, 1, 0);
            map.PlaceMapElements(treasure);
            Player player = Helpers.GetPlayer(Direction.North, 1, 1, map);
            (int x, int y) expectedPosition = (1, 0);
            //act
            IPlayerCommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            //assert
            Assert.Equal(expectedPosition, player.GetCoordinates());
        }

        [Fact]
        public void ShouldPassOnTerrain()
        {
            Player player = Helpers.GetPlayer("toto");

            bool canPass = player.CanPassBy(null);

            Assert.True(canPass);
        }
    }
}
