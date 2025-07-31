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
    public class MapElementTests
    {
        [Fact]
        public void ShouldLostValueAndPlayerShouldObtainOneTreasure()
        {
            //arrange
            IMap map = new Map(3, 3);
            Treasure treasure = new Treasure(1, 1, 0);
            Player player = Helpers.GetPlayer("Indiana");
            int expectedNumberOfTreasures = player.GetNumberOfTreasure()+1;
            //act
            treasure.Interact(player);
            //assert
            Assert.True(
                0 == treasure.NumberOfTreasure
                && expectedNumberOfTreasures == player.GetNumberOfTreasure());
        }

        [Fact]
        public void ShouldNotLostValueAndPlayerShouldNotObtainOneTreasureWhenEmpty()
        {
            IMap map = new Map(3, 3);
            Treasure treasure = new Treasure(0, 1, 0);
            Player player = Helpers.GetPlayer("Indiana");
            int expectedNumberOfTreasures = player.GetNumberOfTreasure();
            //act
            treasure.Interact(player);
            //assert
            Assert.True(
                0 == treasure.NumberOfTreasure
                && expectedNumberOfTreasures == player.GetNumberOfTreasure());
        }
    }
}
