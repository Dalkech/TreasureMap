using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreasureMap;

namespace TreasureMap
{
    public interface IPlayer
    {
        abstract bool CanPassBy(BaseMapElement element);
        abstract void AddTreasure(int numberOfTreasure);
        abstract void Move(int steps);
        abstract void ChangeOrientation(char turnDirection);
        abstract (int x, int y) GetCoordinates();
    }
}
