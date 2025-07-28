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
        [InlineData(3,3, ".\t\t.\t\t.\r\n" 
                        + ".\t\t.\t\t.\r\n" 
                        + ".\t\t.\t\t.\r\n")]
        [InlineData(1, 3, 
            ".\r\n" 
            + ".\r\n" 
            + ".\r\n")]
        [InlineData(3, 1, 
            ".\t\t.\t\t.\r\n")]
        [InlineData(5, 3,
            ".\t\t.\t\t.\t\t.\t\t.\r\n"
            + ".\t\t.\t\t.\t\t.\t\t.\r\n"
            + ".\t\t.\t\t.\t\t.\t\t.\r\n")]
        [InlineData(7, 4,
            ".\t\t.\t\t.\t\t.\t\t.\t\t.\t\t.\r\n"
            + ".\t\t.\t\t.\t\t.\t\t.\t\t.\t\t.\r\n"
            + ".\t\t.\t\t.\t\t.\t\t.\t\t.\t\t.\r\n"
            + ".\t\t.\t\t.\t\t.\t\t.\t\t.\t\t.\r\n")]
        void SettingMap_Should_Match_Bounds(int width, int heigth, string expected)
        {
            //arrange
            TreasureMap.Map map = new(width, heigth);
            //act
            string mapString = map.ToString();
            //assert
            Assert.Equal(expected, mapString);
        }
    }
}
