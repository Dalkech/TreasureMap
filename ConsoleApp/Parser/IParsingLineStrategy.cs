using Application.LineData;
using ConsoleApp.LineValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Parser
{
    internal interface IParsingLineStrategy
    {
        void Execute(string input);
    }
}
