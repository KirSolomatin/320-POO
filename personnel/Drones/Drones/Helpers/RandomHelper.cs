using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    internal static class RandomHelper
    {
        public static int GenerateNumber (int firstValue, int secondValue)
        {
            Random random = new Random();

            return random.Next(firstValue, secondValue);
        }
    }
}
