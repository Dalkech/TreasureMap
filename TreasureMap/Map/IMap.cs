using TreasureMap;

namespace TreasureMap
{
    public interface IMap
    {
        public abstract BaseMapElement? GetMapElement(int x, int y);
        public abstract void PlacePlayers(params IPlayer[] newPlayers);
        public abstract void PlaceMapElements(params BaseMapElement[] newElements);
        public abstract bool PositionIsValid(int x, int y);
        public int GetWidth();
        public int GetHeight();
        public abstract BaseMapElement[,] GetMap();
    }
}