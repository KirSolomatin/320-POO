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
        static int _x { get; set; } = Config.AIRSPACE_WIDTH / 2;
        private static int _y = Config.AIRSPACE_HEIGHT/2;
        private int _width = 50;
        private int _height = 50;

        Pen blackPen = new Pen(Color.Black, 3);
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawEllipse(blackPen, _x, _y, _width, _height);
        }
    }
}
