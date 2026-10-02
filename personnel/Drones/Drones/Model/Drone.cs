using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public partial class Drone
    {
        public DroneStates State { get; private set; } = DroneStates.ROAMING;

        private int _charge;                          // La charge actuelle de la batterie
        private string _name;                         // Un nom
        private int _x;                               // Position en X depuis la gauche de l'espace aérien
        private int _y;                               // Position en Y depuis le haut de l'espace aérien
        private int _targetX;                         // Objectif en X vers lequel le drone se dirige
        private int _targetY;                         // Objectif en Y vers lequel le drone se dirige
        private Charger _charger;                     // La borne de recharge de l'espace aérien

        // Constructeur
        public Drone(int x, int y, string name, Charger charger)
        {
            _x = x;
            _y = y;
            _name = name;
            _charger = charger;
            _charge = RandomHelpers.Next(Config.MAX_LOAD); // La charge initiale de la batterie est choisie aléatoirement

            // Le drone se fixe un objectif aléatoire quelque part dans l'espace aérien
            PickNewTarget();
        }

        #region ================ Modelisation du drone et de son comportement ================

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            switch (State)
            {
                case DroneStates.CRASH:
                    break;                                 // Hors service, immobile

                case DroneStates.LOADING:
                    Recharge();
                    break;

                case DroneStates.ROAMING:
                case DroneStates.LOW_BATTERY:
                    Fly(interval);
                    break;
            }
        }

        // Déplacement vers l'objectif courant, et gestion des transitions d'état qui en découlent
        private void Fly(int interval)
        {
            if (_charge <= 0)
            {
                State = DroneStates.CRASH;
                return;
            }

            double distance = MathHelpers.Distance(_x, _y, _targetX, _targetY);

            if (distance <= Config.SPEED * interval / 1000)                 // L'objectif est atteint (ou tout proche)
            {
                _x = _targetX;
                _y = _targetY;

                if (State == DroneStates.LOW_BATTERY)
                {
                    State = DroneStates.LOADING;                 // Arrivé à la borne, il se met en charge
                }
                else
                {
                    PickNewTarget();                        // Nouvel objectif aléatoire
                }
                return;
            }

            // Déplacement le long du vecteur unitaire vers l'objectif, à la vitesse du drone
            double dx = _targetX - _x;
            double dy = _targetY - _y;
            _x += (int)(dx / distance * Config.SPEED * interval/1000);
            _y += (int)(dy / distance * Config.SPEED * interval/1000);
            _charge--;                                    // Il a dépensé de l'énergie

            if (State == DroneStates.ROAMING && _charge <= Config.LOW_BATTERY_THRESHOLD)
            {
                State = DroneStates.LOW_BATTERY;
                _targetX = _charger.X;                      // L'objectif devient la borne de recharge
                _targetY = _charger.Y;
            }

            // TODO 06: Utiliser FlyHelpers pour savoir si on est dans la zone de turbulence de l'espace aérien
            //          Si c'est le cas, ajouter ou soustraire la force du vent
            //          à la bonne coordonnée (_x ou _y) en fonction des carctéristiques du vent

        }

        // Recharge de la batterie, jusqu'à ce qu'elle soit pleine
        private void Recharge()
        {
            _charge = Math.Min(_charge + Config.RECHARGE_RATE, Config.MAX_LOAD);

            if (_charge >= Config.MAX_LOAD)
            {
                State = DroneStates.ROAMING;
                PickNewTarget();
            }
        }

        // Choix d'un nouvel objectif aléatoire dans l'espace aérien
        private void PickNewTarget()
        {
            _targetX = RandomHelpers.Next(Config.AIRSPACE_WIDTH);
            _targetY = RandomHelpers.Next(Config.AIRSPACE_HEIGHT);
        }

        #endregion

        #region  ================ Rendu graphique  ================

        private const int SIZE = 50;
        private Pen _droneBrush = new Pen(new SolidBrush(Color.Purple), 3);

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(_charge > 0 ? Resources.drone : Resources.boom, _x-SIZE/2, _y-SIZE/2, SIZE, SIZE);
            drawingSpace.Graphics.DrawString($"{this}", TextHelpers.drawFont, TextHelpers.writingBrush, _x-SIZE/2, _y-SIZE);
        }

        // De manière textuelle
        public override string ToString()
        {
            return $"{_name} ({((int)((double)_charge / Config.MAX_LOAD * 100)).ToString()}%)\n{State.ToString()}";
        }
        #endregion

    }
}
