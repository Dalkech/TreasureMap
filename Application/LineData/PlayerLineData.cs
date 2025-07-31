using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;
using TreasureMap.Command;

namespace Application.LineData
{
    public record PlayerLineData(string name, char direction, int x, int y, string commandString) : BaseLineData(x, y)
    {
        public string Name = name;
        public char Direction = direction;
        private readonly string commandString = commandString;

        public IPlayer ToPlayer(IMap map) 
        {
            Direction direction =
                this.Direction switch
                {
                    'E' => TreasureMap.Direction.East,
                    'S' => TreasureMap.Direction.South,
                    'O' => TreasureMap.Direction.West,
                    'N' => TreasureMap.Direction.North,
                };

            return new Player(
                Name,
                x, y,
                direction,
                map
            );
        }

        internal static IPlayer[] ToArray(IReadOnlyList<PlayerLineData> models, IMap map)
        {
            List<IPlayer> results = [];
            foreach (var model in models)
                results.Add(model.ToPlayer(map));
            return [.. results];
        }

        public IReadOnlyList<IPlayerCommand> GetCommands(IPlayer player)
        {
            IReadOnlyList<IPlayerCommand> commands = [];
            for (int i = 0; i < this.commandString.Length; i++)
            {
                IPlayerCommand command =
                    this.commandString[i] switch
                    {
                        'A' => new MoveForwardCommand(player),
                        'R' => new MoveBackwardCommand(player),
                        'D' => new TurnCommand(player, 'D'),
                        'G' => new TurnCommand(player, 'G')
                    };
            }
            return commands;
        }
    }
}
