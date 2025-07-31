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
    internal class ParsingTreasureStrategy(LineParser parser) : BaseParsingLineStrategy(parser), IParsingLineStrategy
    {
        string pattern = @"^P\s*-\s*(?<name>\w+)\s*-\s*(?<x>\d+)\s*-\s*(?<y>\d+)\s*-\s*(?<direction>[NSOE])\s*-\s*(?<command>[ARGD]+)$";

        public void Execute(string input)
        {
            Match match = ParseLine(input, pattern);

            this._parser.PlayerLines.Add(
                new PlayerLineData(
                    match.Groups["name"].Value,
                    match.Groups["direction"].Value[0],
                    int.Parse(match.Groups["x"].Value),
                    int.Parse(match.Groups["y"].Value),
                    match.Groups["command"].Value
                ));
        }
    }
}
