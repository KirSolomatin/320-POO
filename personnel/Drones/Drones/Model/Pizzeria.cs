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

            //Chaque fois quand une pizzeria a été générée on l'ajoute dans la liste 
            pizzerias.Add(this);
        }

        //Méthode permettant de générer plusieurs pizzerias
        public static void GeneratePizzeria(int numberOfPizzerias)
        {
            for (int i = 0; i < numberOfPizzerias; i++)
            {
                Pizzeria pizzeria = new Pizzeria($"Pizzeria {i}", RandomHelpers.Next(Config.AIRSPACE_WIDTH), RandomHelpers.Next(Config.AIRSPACE_HEIGHT));
            }
        }

        public static void RegisterPizzeria(Pizzeria pizzeria)
        {
            try
            {
                bool hasColision = false;

                foreach (Pizzeria pizz in Pizzeria.pizzerias)
                {
                    pizz
                }
            }
            catch
            {
                throw new Exception("Pizzeria existe déjà");
            }
        }

        //Affiche une pizzeria et son nom en-desous
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.FillRectangle(_pizzeriaBrush, posX - SIZE / 2, posY - SIZE / 2, SIZE, SIZE);
            drawingSpace.Graphics.DrawString($"{this.name}", TextHelpers.drawFont, TextHelpers.writingBrush, posX - SIZE / 2, posY - SIZE);
        }
    }
}
