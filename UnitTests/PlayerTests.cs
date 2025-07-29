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
            Player player = Helpers.GetMockedPlayer(name);
            
            string playerString = player.ToString();
            
            Assert.Equal(expected, playerString);
        }

        [Fact]
        public void Should_Not_Pass_On_Montain()
        {
            Player player = Helpers.GetMockedPlayer("toto");

            bool canPass = player.CanPassBy(new Montain());

            Assert.False(canPass);
        }

        [Fact]
        public void Should_Pass_On_Treasure()
        {
            Player player = Helpers.GetMockedPlayer("toto");

            bool canPass = player.CanPassBy(new Treasure(3));

            Assert.True(canPass);
        }

        [Fact]
        public void Should_Pass_On_Terrain()
        {
            Player player = Helpers.GetMockedPlayer("toto");

            bool canPass = player.CanPassBy(null);

            Assert.True(canPass);
        }
    }
}
