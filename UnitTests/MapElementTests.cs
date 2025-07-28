using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace UnitTests
{
    public class MapElementTests
    {
        [Fact]
        public void MontainToken_Should_Be_Displayed()
        {
            Montain montain = new();

            string montainString = montain.ToString();

            Assert.Equal("M", montainString);
        }

        [Theory]
        [InlineData(8, "T(8)")]
        [InlineData(2, "T(2)")]
        [InlineData(1, "T(1)")]
        public void Treasure_Should_Be_Displayed_With_Correct_Number_Of_Treasures(int numberOfTrasure, string expected)
        {
            Treasure treasure = new(numberOfTrasure);

            string treasureString = treasure.ToString();

            Assert.Equal(expected, treasureString);
        }       
    }
}
