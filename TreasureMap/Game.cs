using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap.Command;

namespace TreasureMap
{
    public class Game(GameOptions options) : IGame
    {
        private GameOptions options = options;

        public void Play()
        {
            int maxNumberOfTurn = options.PlayerCommandLists.Max(commands => commands.Count);
            for (int i = 0; i < maxNumberOfTurn; i++)
                foreach(var commands in options.PlayerCommandLists)
                    if(commands.ElementAtOrDefault(i) is IPlayerCommand command)
                        command.Execute();
        }
    }
}
