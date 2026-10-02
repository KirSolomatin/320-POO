namespace Drones
{
    // La classe AirSpace repr�sente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fen�tre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {
        // La flotte est l'ensemble des drones qui �voluent dans notre espace a�rien
        private List<Drone> _fleet;
        private Charger _charger;

        private BufferedGraphicsContext _currentContext;
        private BufferedGraphics _airspace;

        private static Wind _turbulence = null;

        // TODO 04: Déclarer et initialiser la propriété statique 'Turbulence', de type Wind

        // Initialisation de l'espace a�rien avec un certain nombre de drones
        public AirSpace(List<Drone> fleet, Charger charger)
        {
            InitializeComponent();
            this.ClientSize = new Size(Config.AIRSPACE_WIDTH, Config.AIRSPACE_HEIGHT);
            // Gets a reference to the current BufferedGraphicsContext
            _currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            _airspace = _currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            _fleet = fleet;
            _charger = charger;
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            _airspace.Graphics.Clear(Color.AliceBlue);

            _charger.Render(_airspace);

            // draw drones
            foreach (Drone drone in _fleet)
            {
                drone.Render(_airspace);
            }

            // draw turbulence zone
            // TODO 05: Corriger ce code pour afficher correctement la zone
            _airspace.Graphics.DrawRectangle(new Pen(Color.Orange), 0,0,0,0);

            _airspace.Render();
        }

        // Calcul du nouvel �tat apr�s que 'interval' millisecondes se sont �coul�es
        private void Update(int interval)
        {
            foreach (Drone drone in _fleet)
            {
                drone.Update(interval);
            }
        }

        // M�thode appel�e � chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }
    }
}