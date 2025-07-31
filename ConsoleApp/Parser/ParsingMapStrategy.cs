using Application.LineData;
using ConsoleApp.LineValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp.Parser
{
    internal class ParsingMapStrategy(LineParser parser) : BaseParsingLineStrategy(parser), IParsingLineStrategy
    {
        private const string pattern = @"^C\s*-\s*(?<largeur>\d+)\s*-\s*(?<hauteur>\d+)$",
            widthKey = "largeur",
            heigthKey = "hauteur";

        public void Execute(string input)
        {
            Match match = ParseLine(input, pattern);

            this._parser.MapLineData =
                new MapLineData(
                int.Parse(match.Groups[widthKey].Value),
                int.Parse(match.Groups[heigthKey].Value)
            );
        }
    }
}
