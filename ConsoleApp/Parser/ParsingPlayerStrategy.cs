using ConsoleApp.LineValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Parser
{
    internal class ParsingPlayerStrategy(LineParser parser) : BaseParsingLineStrategy(parser), IParsingLineStrategy
    {
        public void Execute(string input)
        {
            throw new NotImplementedException();
        }
    }
}
