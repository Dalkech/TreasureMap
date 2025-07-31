using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;
using TreasureMap.Command;

namespace UnitTests
{
    public class GameTests
    {
        [Fact]
        public void ShouldPlayerMovePlayer()
        {
            //arrange 
            Map map = new Map(10, 10);
            map.PlaceMapElements(
                new Montain(0, 0),
                new Treasure(1, 2, 3)
            );
            IPlayer player = Mockup.Helpers.GetPlayer(Direction.North, 2, 3, map);
            map.PlacePlayers(player);

            //act
            IReadOnlyList<IPlayerCommand> playerCommands =
            [
                new MoveForwardCommand(player), //2,2
                new TurnCommand(player, 'D'), //EAST
                new MoveBackwardCommand(player) //1,2
            ];
            new Game(
                new GameOptions { PlayerCommandLists = [playerCommands]}
                ).Play();

            //assert 
            Assert.Equal((1, 2), player.GetCoordinates());
        }
    }
}
