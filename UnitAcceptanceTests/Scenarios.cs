
using Application;
using Application.LineData;
using System;
using System.Text;
using System.Text.Json;

namespace UnitAcceptanceTests
{
    public class Scenarios
    {

        /// <summary>
        /// First Scenario 
        /// ==========================
        /// Start: 
        /// ==========================
        /// M       .       .       .
        /// P1      .       .       .
        /// T(1)    .       T(2)    P2
        /// .       .       .       M
        /// 
        /// ==========================
        /// Result : 
        /// ==========================
        /// M       .       .       .
        /// .       .       .       .
        /// T(0)    P1      P2      .
        /// .       .       .       M 
        /// </summary>
        [Fact]
        public void Scenario1()
        {
            MapLineData map = new MapLineData(4,4);
            IReadOnlyList<MontainLineData> montains = [
                    new MontainLineData(0,0),
                    new MontainLineData(3,3)
                ];
            IReadOnlyList<TreasureLineData> treasures = [
                    new TreasureLineData(1,0,2),
                    new TreasureLineData(2,2,2),
                ];
            IReadOnlyList<PlayerLineData> players = [
                    new PlayerLineData("Player1", 'N', 0, 1, "ARDAA"),
                    new PlayerLineData("Player2", 'O', 3, 2, "ARA"),
                ];

            PlayGameFromFileResponse expectedResponse = new ()
            {
                MapWidth = 4,
                MapHeight = 4,
                MapElements = [
                        new MapElementDto { Token = 'M', X = 0, Y = 0},
                        new MapElementDto { Token = 'T', X = 0, Y = 2, NumberOfTreasure = 0},
                        new MapElementDto { Token = 'T', X = 2, Y = 2, NumberOfTreasure = 0},
                        new MapElementDto { Token = 'M', X = 3, Y = 3},
                    ],
                Scores = [
                    new PlayerScore("Player1", (1,2), TreasureMap.Direction.East, 1),
                    new PlayerScore("Player1", (2,2), TreasureMap.Direction.West, 2),
                    ]
            };

            PlayGameFromFile playGame = new();
            PlayGameFromFileRequest request = new (
              map,
              treasures,
              montains,
              players
            );

            string expected = SerializeResponses(expectedResponse);
            string response = SerializeResponses(playGame.Handle(request));
            Assert.Equal(expected, response);
        }

        private string SerializeResponses(PlayGameFromFileResponse response)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("MAP ELEMENTS:\n");
            sb.AppendLine(JsonSerializer.Serialize(response.MapElements));
            sb.Append("SCORES:\n");
            sb.AppendLine(JsonSerializer.Serialize(response.Scores));

            return sb.ToString();
        }
    }
}
