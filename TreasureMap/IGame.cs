using TreasureMap.Command;

namespace TreasureMap
{
    public record GameOptions
    {
        public required IReadOnlyList<IReadOnlyList<BasePlayerCommand>> PlayerCommandLists { get; set; }
    }

    public record GameData
    {
        public int MapHeight {get;set;}
        public int MapWidth {get;set;}
        public required IReadOnlyList<IPlayer> Players { get; set; }
        public required BaseMapElement[,] MapElements { get; set; }
    }

    public interface IGame
    {
        public abstract void Play();
    }
}