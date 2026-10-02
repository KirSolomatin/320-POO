namespace Drones
{
    // Outils pour la génération de valeurs aléatoires
    internal static class RandomHelpers
    {
        private static readonly Random alea = new Random();

        // Valeur aléatoire entre 0 (inclus) et max (exclu)
        public static int Next(int max) => alea.Next(max);

        // Valeur aléatoire entre min (inclus) et max (exclu)
        public static int Next(int min, int max) => alea.Next(min, max);

        // TODO 07: Créer un helper qui choisit une des directions de vent possible au hasard
    }
}
