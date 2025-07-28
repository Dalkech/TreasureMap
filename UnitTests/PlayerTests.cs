using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

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
            Player player = new(name);
            
            string playerString = player.ToString();
            
            Assert.Equal(expected, playerString);
        }
    }
}
