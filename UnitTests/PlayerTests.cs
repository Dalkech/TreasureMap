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

        [Theory]
        [InlineData("Jean", "(Jean)")]
        [InlineData("Josiane", "(Josiane)")]
        [InlineData("Toto", "(Toto)")]
        public void Player_Should_Be_Displayed_With_The_Right_Name(string name, string expected)
        {
            Player player = Helpers.GetPlayer(name);
            
            string playerString = player.ToString();
            
            Assert.Equal(expected, playerString);
        }

        [Fact]
        public void Should_Not_Pass_On_Montain()
        {
            //arrange
            IMap map = new Map(3, 3);
            map.PlaceMapElements(new Montain(1, 0));
            Player player = Helpers.GetPlayer(Direction.North, 1, 1, map);
            //act
            ICommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            //assert
            Assert.Equal((1, 1), player.GetCoordinates());
        }

        [Fact]
        public void Should_Not_Pass_On_OtherPlayer()
        {
            //arrange
            IMap map = new Map(3, 3);
            Player player = Helpers.GetPlayer(Direction.North, 1,1, map);
            Player obstaclePlayer = Helpers.GetPlayer(Direction.North, 1, 0, map);
            map.PlacePlayers(obstaclePlayer);
            //act
            ICommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            //assert
            Assert.Equal( (1,1), player.GetCoordinates());
        }

        [Fact]
        public void Should_Pass_On_Treasure()
        {
            //arrange
            IMap map = new Map(3, 3);
            Treasure treasure = new Treasure(1, 1, 0);
            map.PlaceMapElements(treasure);
            Player player = Helpers.GetPlayer(Direction.North, 1, 1, map);
            //act
            ICommand moveForward = new MoveForwardCommand(player);
            moveForward.Execute();
            //assert
            Assert.Equal((0, 1), player.GetCoordinates());
        }

        [Fact]
        public void Should_Pass_On_Terrain()
        {
            Player player = Helpers.GetPlayer("toto");

            bool canPass = player.CanPassBy(null);

            Assert.True(canPass);
        }
    }
}
