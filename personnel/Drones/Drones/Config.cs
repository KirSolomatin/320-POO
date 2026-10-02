namespace Drones
{
    // Constantes de configuration de la simulation
    internal static class Config
    {
        public const int AIRSPACE_WIDTH = 1600;            // Dimensions de l'espace aérien
        public const int AIRSPACE_HEIGHT = 800;

        public const int SPEED = 50;                       // Vitesse de déplacement d'un drone (pixels par frame)
       
        public const int MAX_LOAD = 1000;                 // Charge maximum de la batterie d'un drone
        public const int LOW_BATTERY_THRESHOLD = MAX_LOAD / 5; // Niveau de charge en dessous duquel le drone rejoint la borne
        public const int RECHARGE_RATE = 10;                // La recharge est 10x plus rapide que la décharge (1 par frame)
    }
}
