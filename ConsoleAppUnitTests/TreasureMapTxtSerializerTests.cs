using Application;
using ConsoleApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppUnitTests
{
    public class TreasureMapTxtSerializerTests
    {

        [Fact]
        public void TestSerialization()
        {
            PlayGameFromFileResponse response = new PlayGameFromFileResponse
            {
                MapWidth = 8,
                MapHeight = 6,
                MapElements = [
                    new MapElementDto{ Token = 'T', NumberOfTreasure = 1, X = 1, Y = 1 },
                    new MapElementDto{ Token = 'M', X = 5, Y = 0 },
                    new MapElementDto{ Token = 'T', NumberOfTreasure = 66, X = 5, Y = 3 },
                    ],
                Scores = [
                    new PlayerScore("Toto", (2, 2), TreasureMap.Direction.North, 0)
,                   new PlayerScore("Titi", (5, 4), TreasureMap.Direction.West, 666)
                ]
            };

            string expected = 
                "C - 8 - 6" +
                "\nT - 1 - 1 - 1" +
                "\nM - 5 - 0" +
                "\nT - 5 - 3 - 66" +
                "\nA - Toto - 2 - 2 - N - 0" +
                "\nA - Titi - 5 - 4 - O - 666";
            
            string serializedRespons = TreasureMapTxtSerializer
                .SerilizeResponse(response)
                .Aggregate((l1,l2) => string.Format("{0}\n{1}", l1,l2));

            Assert.Equal(expected, serializedRespons);
        }

    }
}
