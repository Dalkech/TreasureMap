using Application.LineData;

namespace Application
{
    public record PlayGameFromFileRequest(
        MapLineData mapLineData,
        IReadOnlyList<TreasureLineData> treasureLines,
        IReadOnlyList<MontainLineData> montainLines,
        IReadOnlyList<PlayerLineData> playerLines
        )
    {
        public readonly MapLineData MapLine = mapLineData;
        public readonly IReadOnlyList<TreasureLineData> TreasureLines = treasureLines;
        public readonly IReadOnlyList<MontainLineData> MontainLines = montainLines;
        public readonly IReadOnlyList<PlayerLineData> playerLines = playerLines;
    }
}