using Drones.Helpers;
using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Model
{
    public class Charger
    {
        public static int xPosition { get; private set; } = Config.AIRSPACE_WIDTH / 2;
        public static int yPosition { get; private set; } = Config.AIRSPACE_HEIGHT/2;
        private int _width = 50;
        private int _height = 50;

        Pen blackPen = new Pen(Color.Black, 3);
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawEllipse(blackPen, xPosition, yPosition, _width, _height);
        }
    }
}
