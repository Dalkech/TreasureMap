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
@" - - 
 - - 
 - - 
")]
        [InlineData(1, 3,
@" 
 
 
")]
        [InlineData(3, 1,
@" - - 
")]
        [InlineData(5, 3,
@" - - - - 
 - - - - 
 - - - - 
")]
        [InlineData(7, 4,
@" - - - - - - 
 - - - - - - 
 - - - - - - 
 - - - - - - 
")]
        void SettingMap(int x, int y, string expected)
        {
            //arrange
            TreasureMap.Map map = new(x, y);
            //act
            string mapString = map.ToString();
            //assert
            Assert.Equal(expected, mapString);
        }
    }
}
