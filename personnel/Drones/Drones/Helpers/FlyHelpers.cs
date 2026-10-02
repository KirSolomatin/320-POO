using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public static class FlyHelpers
    {
        public static bool IsInside(int x, int y, int zonex, int zoney, int zonew, int zoneh)
        {
            Rectangle rectangle = new Rectangle(zonex, zoney, zonew, zoneh);
            return rectangle.Contains(x, y);
        }
    }
}
