using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class MapTests
    {
        [Theory]
        [InlineData(3,3,
@" - - - 
 - - - 
 - - - ")]

        void SetUpMap_Output_Should_Match(int x, int y, string expected)
        {
            //arrange
            TreasureMap.Map.Map map = TreasureMap.Map.Map.Create();
            //act
            string mapString = map.ToString();
            //assert
            Assert.Equal(expected, mapString);
        }
    }
}
