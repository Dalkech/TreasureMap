using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureMap
{
    public abstract class BaseMapElement(char mapToken) : IDIsplayable
    {
        protected char mapToken = mapToken;
        public override string ToString() {
            return mapToken.ToString();
        }
    }
}
