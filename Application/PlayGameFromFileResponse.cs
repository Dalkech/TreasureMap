using Application.LineData;
using TreasureMap;

namespace Application
{
    public record PlayerScore
        (string Name, (int x, int y) coordinates, Direction direction, int numberOfTreasure)
    {
        public readonly string Name = Name;

        public readonly (int x, int y) Coordinates = coordinates;

        public readonly char Orientation = 
            direction switch
            {
                Direction.North => 'N',
                Direction.South => 'S',
                Direction.West => 'O',
                Direction.East => 'E',
                _ => throw new ArgumentException(string.Format("Direction innatendue en argument {0}", direction)) 
            };

        public readonly int numberOfTreasure = numberOfTreasure;

        internal static IReadOnlyList<PlayerScore> ToPlayerScores(IReadOnlyList<Player> players)
        {
            List<PlayerScore> result = [];

            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];
                result.Add(new PlayerScore(
                    player.Name,
                    player.GetCoordinates(),
                    player.Direction,
                    player.GetNumberOfTreasure()
                    ));
            }

            return result; 
        }
    }

    public record MapElementDto
    {
        public char Token { get; init; }
        public int X { get; init; } = 0;
        public int Y { get; init; } = 0;
        public int NumberOfTreasure { get; init; } = 0;
        public static IReadOnlyList<MapElementDto> ToMapElements(IMap map)
        {
            List<MapElementDto> result = [];
            BaseMapElement[,] elements = map.GetMap();
            int
                width = map.GetWidth(),
                heigth = map.GetHeight();
            
            for (int y = 0; y < heigth; y++) 
                for (int x = 0; x < width; x++)
                {
                    BaseMapElement element = elements[x, y];
                    if (element is null)
                        continue;

                    MapElementDto dto =
                        element switch
                        {
                            Treasure treasure => new MapElementDto
                            {
                                NumberOfTreasure = treasure.NumberOfTreasure,
                                Token = treasure.Token,
                                X = treasure.Coordinates.x,
                                Y = treasure.Coordinates.y
                            },
                            _ => new MapElementDto
                            {
                                Token = element.Token,
                                X = element.Coordinates.x,
                                Y = element.Coordinates.y
                            }
                        };

                    result.Add(dto);
                }

            return result;
        } 
    }

    public record PlayGameFromFileResponse
    {
        public int MapHeight { get; init; }
        public int MapWidth { get; init; }
        public IReadOnlyList<MapElementDto> MapElements { get; init; } = [];
        public IReadOnlyList<PlayerScore> Scores { get; init; } = [];
    }
}