using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;
using TreasureMap.Command;
using TreasureMap.MapElement;
using UnitTests.Mockup;

namespace UnitTests
{
    public class MapElementTests
    {
        [Fact]
        public void MontainToken_Should_Be_Displayed()
        {
            Montain montain = new(1,1);

            string montainString = montain.ToString();

            Assert.Equal("M", montainString);
        }

        [Theory]
        [InlineData(8, "T(8)")]
        [InlineData(2, "T(2)")]
        [InlineData(1, "T(1)")]
        public void Treasure_Should_Be_Displayed_With_Correct_Number_Of_Treasures(int numberOfTrasure, string expected)
        {
            Treasure treasure = new(numberOfTrasure, 1,1);

            string treasureString = treasure.ToString();

            Assert.Equal(expected, treasureString);
        }

        [Fact]
        public void Treasure_Should_Lost_Value()
        {
            //arrange
            IMap map = new Map(3, 3);
            Treasure treasure = new Treasure(1, 1, 0);
            //act
            treasure.Interact(Helpers.GetPlayer("Indiana"));
            //assert
            Assert.Equal(0, treasure.NumberOfTreasure);
        }

        [Fact]
        public void Treasure_Should_Not_Lost_Value_When_Empty()
        {
            //arrange
            IMap map = new Map(3, 3);
            Treasure treasure = new Treasure(0, 1, 0);
            //act
            treasure.Interact(Helpers.GetPlayer("Indiana"));
            //assert
            Assert.Equal(0, treasure.NumberOfTreasure);
        }
    }
}
