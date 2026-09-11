using Drones.Helpers;
using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        private int _charge;                            // La charge actuelle de la batterie
        private string _name;                           // Un nom
        private int _x;                                 // Position en X depuis la gauche de l'espace aérien
        private int _y;                                 // Position en Y depuis le haut de l'espace aérien
        private int _targetX;                           // Le point X où le drone se dirige
        private int _targetY;                          // Le point Y où le drone se dirige

        public int Charge { get => _charge; private set => _charge = value; }
        public string Name { get => _name; }
        public int X { get => _x; private set => _x = value; }
        public int Y { get => _y; private set => _y = value; }
        public int TargetX { get => _targetX; private set => _targetX = value; }
        public int TargetY { get => _targetY; private set => _targetY = value; }


        // Constructeur
        public Drone(int x, int y, string name, int xTarget, int yTarget)
        {
            this.X = x;
            this.Y = y;
            this._name = name;
            this.TargetX = xTarget;
            this.TargetY = yTarget;
            Charge = RandomHelper.GenerateNumber(0, Config.MAX_LOAD); // La charge initiale de la batterie est choisie aléatoirement
        }

        #region ================ Modelisation du drone et de son comportement ================

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (Charge <= 0) return;                     // S'il n'a plus de charge, il ne peut plus bouger
            //Random alea = new Random();
            //X += 2;                                    // Il s'est déplacé de 2 pixels vers la droite
            //Y += alea.Next(-2, 3);                     // Il s'est déplacé d'une valeur aléatoire vers le haut ou le bas
            double deltaX = TargetX - X;
            double deltaY = TargetY - Y;
            if (deltaX > 0) X += Config.SPEED;
            else X -= Config.SPEED;
            if (deltaY > 0) Y += Config.SPEED;
            else Y -= Config.SPEED;
            Charge--;                                  // Il a dépensé de l'énergie
        }

        #endregion

        #region  ================ Rendu graphique  ================

        private const int SIZE = 50;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Charge > 0 ? Resources.drone : Resources.boom, X-Drone.SIZE/2, Y - Drone.SIZE / 2, Drone.SIZE, Drone.SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, X + 5, Y - 25);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{Name} ({((int)((double)Charge / 1000 * 100)).ToString()}%)";
        }
        #endregion

    }
}
