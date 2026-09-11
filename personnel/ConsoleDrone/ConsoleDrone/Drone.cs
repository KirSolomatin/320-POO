using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Drone
    {
        public int posX;
        public int posY;
        public int battery;
        public ConsoleColor color;

        public Drone(int posX, int posY, int battery, ConsoleColor color)
        {
            this.posX = posX;
            this.posY = posY;
            this.battery = battery;
            this.color = color;
        }

        public void ConsoleToShow()
        {
            if (battery > 0)
            {
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = color;
                Console.Write("x-0-x");
                Console.SetCursorPosition(posX, posY + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{battery}%");
            }

            else
            {
                ToDieMessage();
            }
        }

        public void StatusChange()
        {
            posX += 1;
            battery -= 2;
        }

        public void ToDieMessage()
        {
            Console.SetCursorPosition(posX, posY);

            Console.WriteLine("____");
            Console.SetCursorPosition(posX + 4, posY);
            Console.WriteLine("Il est mort");
        }
    }
}
