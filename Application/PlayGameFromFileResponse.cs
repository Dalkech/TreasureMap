using Application.LineData;
using TreasureMap;

namespace Application
{
    public record PlayerScore
        (string Name, (int x, int y) coordinates, Direction direction, int numberOfTreasure)
    {
        public string Name { get;set; }
        public (int x, int y) Coordinates { get; set; }

        public char Orientation = 
            direction switch
            {
                Direction.North => 'N',
                Direction.South => 'S',
                Direction.West => 'O',
                Direction.East => 'E',
                _ => throw new ArgumentException(string.Format("Direction innatendue en argument {0}", direction)) 
            };

        public int numberOfTreasure { get; set; }
    }

    public record PlayGameFromFileResponse
    {
        public IReadOnlyList<BaseMapElement> MapElements = [];
        public IReadOnlyList<PlayerScore> scores = []; 
    }
}