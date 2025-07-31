using Application.LineData;
using ConsoleApp.LineValidation;
using System.Text.Json;

namespace ConsoleAppUnitTests
{
    public class ParsingTests
    {
        private LineParser MockParserWithMapLine()
        {
            var parser = new LineParser();
            parser.Parse("C - 8 - 8");
            return parser;
        }

        [Fact]
        public void ParseMap()
        {
            // arrange 
            LineParser parser = new();
            string lineToParse = "C - 3 - 3 ";
            MapLineData expected = new MapLineData(3, 3);

            parser.Parse(lineToParse);
            MapLineData result = parser.MapLineData;

            Assert.Equal(expected, result);
        }


        [Fact]
        public void ParseTreasure()
        {
            // arrange 
            LineParser parser = MockParserWithMapLine();
            string lineToParse = "T - 3 - 3 - 666";
            TreasureLineData expected = new(666, 3, 3);
             
            parser.Parse(lineToParse);
            TreasureLineData result = parser.TreasureLines[0];

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseMontain()
        {
            // arrange 
            LineParser parser = MockParserWithMapLine();
            string lineToParse = "M - 3 - 3";
            MontainLineData expected = new (3, 3);

            parser.Parse(lineToParse);
            MontainLineData result = parser.MontainLines[0];

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParsePlayer()
        {
            // arrange 
            LineParser parser = MockParserWithMapLine();
            string lineToParse = "A - Toto - 2 - 1 - N - AGADR ";
            PlayerLineData expected = new("Toto", 'N', 3, 3, "AGADR");

            parser.Parse(lineToParse);
            PlayerLineData result = parser.PlayerLines[0];

            //serialization du to compare issues
            Assert.Equal(
                JsonSerializer.Serialize(expected), 
                JsonSerializer.Serialize(result));
        }

        [Theory]
        [InlineData("#")]
        [InlineData(" ")]
        public void ParseIgnoreLine(string lineToIgnore)
        {
            // arrange 
            LineParser parser = MockParserWithMapLine();
            LineParser expected = MockParserWithMapLine();

            // act
            parser.Parse(lineToIgnore);

            // assert
            Assert.True(
                expected.MontainLines.Count == parser.MontainLines.Count
                && expected.TreasureLines.Count == parser.MontainLines.Count()
                && expected.PlayerLines.Count == parser.PlayerLines.Count()
            );
        }

        [Fact]
        public void ParsingErrorFirstMapLine()
        {
            LineParser parser = new();

            Action parseWrongLine = () => parser.Parse("T - 666 - 666");

            Assert.Throws<ArgumentException>(parseWrongLine);
        }

        [Theory]
        [InlineData("Z - 0 - 0 (no parsing rule existing)")]
        [InlineData("Wrong Text Line")]
        [InlineData("M - 0 (no y)")]
        [InlineData("T - chocolat - 0 - 0 (wrong treasure format)")]
        [InlineData("P - 0 - 0 - N (no commands)")]
        [InlineData("P - 0 - 0 - D - AG (wrong direction)")]
        public void ParsingError(string line)
        {
            LineParser parser = MockParserWithMapLine();

            Action parseWrongLine = () => parser.Parse(line);

            Assert.Throws<ArgumentException>(parseWrongLine);
        }
    }
}
 