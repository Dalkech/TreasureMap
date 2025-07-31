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
    internal class ParsingMontainStrategy(LineParser parser) : BaseParsingLineStrategy(parser), IParsingLineStrategy
    {
        private const string 
            pattern = @"^M\s*-\s*(?<x>\d+)\s*-\s*(?<y>\d+)\s*$",
            xKey = "x",
            yKey = "y";

        public void Execute(string input)
        {
            Match match = ParseLine(input, pattern);

            this._parser.MontainLines.Add(
                new MontainLineData(
                    int.Parse(match.Groups[xKey].Value),
                    int.Parse(match.Groups[yKey].Value)
                    )
                );
        }
    }
}
