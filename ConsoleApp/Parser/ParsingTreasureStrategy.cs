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
        private const string pattern = @"^T\s*-\s*(?<x>\d+)\s*-\s*(?<y>\d+)\s*-\s*(?<value>\d+)\s*$";
        public void Execute(string input)
        {
            Match match = ParseLine(input, pattern);

            this._parser.TreasureLines.Add(
                new TreasureLineData(
                    int.Parse(match.Groups["value"].Value),
                    int.Parse(match.Groups["x"].Value),
                    int.Parse(match.Groups["y"].Value)
                ));
        }
    }
}