using Application.LineData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;
using TreasureMap.Command;

namespace Application
{
    public class PlayGameFromFile : IUseCase<PlayGameFromFileRequest, PlayGameFromFileResponse>
    {
        public PlayGameFromFileResponse Handle(PlayGameFromFileRequest request)
        {
            IMap map = request.MapLine.ToMap();
            map.PlaceMapElements(MontainLineData.ToMapElements(request.MontainLines));
            map.PlaceMapElements(TreasureLineData.ToMapElements(request.TreasureLines));

            // set commands and player
            List<Player> players = [];
            List<IReadOnlyList<IPlayerCommand>> playerCommands = [];
            foreach(PlayerLineData playerLine in request.playerLines)
            {
                Player player = playerLine.ToPlayer(map);
                players.Add(player);
                IReadOnlyList<IPlayerCommand> playerCommand = playerLine.GetCommands(player);
                playerCommands.Add(playerCommand);
            }
            
            map.PlacePlayers([.. players]);
            IGame game = new Game(
                new GameOptions { PlayerCommandLists = playerCommands }
                );

            game.Play();

            return new PlayGameFromFileResponse
            {
                MapHeight = request.MapLine.Height,
                MapWidth = request.MapLine.Width,
                MapElements = MapElementDto.ToMapElements(map),
                Scores = PlayerScore.ToPlayerScores(players)
            }; 
        }
    }
}
