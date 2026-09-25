using Drones.Helpers;
using Drones.Properties;

namespace Drones.Model
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
        private State state;                            //Etats du drone

        enum State { CRASH, LOW_BATTERY, LOADING, ROAMING };
        


        // Constructeur
        public Drone(int x, int y, string name, int xTarget, int yTarget)
        {
            _x = x;
            _y = y;
            _name = name;
            _charge = RandomHelper.GenerateNumber(20, Config.MAX_LOAD); // La charge initiale de la batterie est choisie aléatoirement
            this.state = State.ROAMING;

            // Le drone se fixe un objectif aléatoire quelque part dans l'espace aérien
            _targetX = RandomHelper.GenerateNumber(0, Config.AIRSPACE_WIDTH);
            _targetY = RandomHelper.GenerateNumber(0, Config.AIRSPACE_HEIGHT);
        }

        #region ================ Modelisation du drone et de son comportement ================

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            if (_charge <= 0) return;                     // S'il n'a plus de charge, il ne peut plus bouger

            if (_charge < 50)                           //Si le charge est bas
            {
                //On change l'etat du drone
                state = State.LOW_BATTERY;

                //On change l'objectif du drone à la borne de recharge
                _targetX = Charger.xPosition;
                _targetY = Charger.yPosition;
            }
            double distance = MathHelpers.Distance(_x, _y, _targetX, _targetY);

            if (distance <= Config.speed * interval / 1000)                 // L'objectif est atteint (ou tout proche)
            {
                if (state == State.LOW_BATTERY) // La borne est atteint
                {
                    //Drone s'arrête
                    _x = Charger.xPosition;
                    _y = Charger.yPosition;
                    Config.speed = 0;

                    state = State.LOADING;               //On change l'etat du drone
                    while (_charge <= Config.MAX_LOAD - 2)
                    {
                        //Drone se charge
                        _charge += 2;
                        state = State.ROAMING;          //On change l'etat du drone
                    }

                    _charge = Config.MAX_LOAD;
                }

                //Choisi un nouvel objectif
                _targetX = RandomHelper.GenerateNumber(0, Config.AIRSPACE_WIDTH);
                _targetY = RandomHelper.GenerateNumber(0, Config.AIRSPACE_HEIGHT);
            }
            else
            {
                // Déplacement le long du vecteur unitaire vers l'objectif, à la vitesse du drone
                double dx = _targetX - _x;
                double dy = _targetY - _y;
                _x += (int)(dx / distance * Config.speed * interval / 1000);
                _y += (int)(dy / distance * Config.speed * interval / 1000);
                _charge--;                                    // Il a dépensé de l'énergie
            }

        }

        #endregion

        #region  ================ Rendu graphique  ================

        private const int SIZE = 50;
        private Pen droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(_charge > 0 ? Resources.drone : Resources.boom, _x - SIZE / 2, _y - SIZE / 2, SIZE, SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x - SIZE / 2, _y - SIZE);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{_name} ({((int)((double)_charge / Config.MAX_LOAD * 100)).ToString()}%)";
        }
        #endregion

    }
}
