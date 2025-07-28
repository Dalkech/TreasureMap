using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    sealed public class Player(string name) : IDIsplayable
    {
        private const string displayFormat = "({0})";
        
        private readonly string Name = name;
        public override string ToString()
        {
            return string.Format(displayFormat, Name);
        }
    }
}
