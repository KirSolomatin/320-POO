using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class Pizzeria
    {
        //Le nom de pizzeria
        public string name { get; private set; }

        //Les coordonnées 
        public int posX { get; private set; }
        public int posY { get; private set; }
        static public List<Pizzeria> pizzerias = new List<Pizzeria>();

        private const int SIZE = 50;

        private static Brush _pizzeriaBrush = new SolidBrush(Color.Gray);


        public Pizzeria (string name, int posX, int posY)
        {
            this.name = name;
            this.posX = posX;
            this.posY = posY;

            pizzerias.Add(this);
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(_pizzeriaBrush, posX - SIZE / 2, posY - SIZE / 2, SIZE, SIZE);
        }
    }
}
