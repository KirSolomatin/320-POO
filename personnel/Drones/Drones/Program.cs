namespace Drones
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Création de la borne de recharge
            Charger charger = new Charger(Config.AIRSPACE_WIDTH / 2, Config.AIRSPACE_HEIGHT / 2);

            // Création de la flotte de drones
            List<Drone> fleet = new List<Drone>();
            fleet.Add(new Drone(Config.AIRSPACE_WIDTH / 2, Config.AIRSPACE_HEIGHT / 2, "Joe", charger));
            fleet.Add(new Drone(Config.AIRSPACE_WIDTH / 2, Config.AIRSPACE_HEIGHT / 2, "Joe", charger));
            fleet.Add(new Drone(Config.AIRSPACE_WIDTH / 2, Config.AIRSPACE_HEIGHT / 2, "Joe", charger));

            // Démarrage
            Application.Run(new AirSpace(fleet, charger));
        }
    }

    // TODO 00: Implémenter les TODOs dans l'ordre de leur numéros
    //          Faire un commit à chaque fois qu'un TODO a été fait.
    //          Demander la solution si vous êtes bloqué.

}