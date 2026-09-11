using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Drone drone1 = new Drone();


            while (drone1.battery > 0)
            {
                drone1.Run();
            }
            Console.ReadKey();
        }
    }
}