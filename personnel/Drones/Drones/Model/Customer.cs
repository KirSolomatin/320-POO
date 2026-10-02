using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class Customer
    {
        //Le nom de client
        public string name { get; private set; }

        //Les coordonnées 
        public int posX { get; private set; }
        public int posY { get; private set; }

        static public List<Customer> customers = new List<Customer>();

        private const int SIZE = 10;

        private static Brush _pizzeriaBrush = new SolidBrush(Color.Green);


        public Customer(string name, int posX, int posY)
        {
            this.name = name;
            this.posX = posX;
            this.posY = posY;

            customers.Add(this);
        }

        public static void GenerateClients(int numberOfClients)
        {
            for (int i = 0; i < numberOfClients; i++)
            {
                Customer client = new Customer($"Client {i}", RandomHelpers.Next(Config.AIRSPACE_WIDTH), RandomHelpers.Next(Config.AIRSPACE_HEIGHT));
            }
        }

        //Affiche un client et son nom en-desous
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(_pizzeriaBrush, posX - SIZE / 2, posY - SIZE / 2, SIZE, SIZE);
            drawingSpace.Graphics.DrawString($"{this.name}", TextHelpers.drawFont, TextHelpers.writingBrush, posX - SIZE / 2, posY - SIZE);
        }
    }
}
