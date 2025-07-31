using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Serializer
{
    public static class TreasureMapTxtSerializer
    {
        private const string
            // C - widht - height
            mapPattern = "C - {0} - {1}",
            // A - Name - X - Y - Direction - NumberOftreasure 
            playerPattern = "A - {0} - {1} - {2} - {3} - {4}",
            // M - X - Y
            montainPattern = "M - {0} - {1}",
            // T - X - Y - NumberOfTreasures
            treasurePattern = "T - {0} - {1} - {2}"
            ;

        public static IEnumerable<string> SerilizeResponse(PlayGameFromFileResponse response)
        {
            yield return string.Format(mapPattern, response.MapWidth, response.MapHeight);

            for(int i = 0; i < response.MapElements.Count; i++) {
                MapElementDto element = response.MapElements[i];
                yield return element.Token switch
                {
                    'T' => string.Format(treasurePattern, element.X, element.Y, element.NumberOfTreasure),
                    _ => string.Format(montainPattern, element.X, element.Y)
                };
            }

            for(int i = 0; i < response.Scores.Count; i++)
            {
                PlayerScore score = response.Scores[i];
                yield return string.Format(playerPattern,
                    score.Name, score.coordinates.x, score.coordinates.y,
                    score.Orientation, score.numberOfTreasure);
            }
        }
    }
}
