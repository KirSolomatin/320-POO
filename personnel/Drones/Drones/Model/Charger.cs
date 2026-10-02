namespace Drones
{
    // La borne de recharge à laquelle les drones viennent se ressourcer
    public class Charger
    {
        private const int SIZE = 20;                  // Diamètre de la borne, en pixels
        private static readonly Pen _chargerBrush = new Pen(new SolidBrush(Color.Green), 3);

        private int _x;                                // Position en X depuis la gauche de l'espace aérien
        private int _y;                                // Position en Y depuis le haut de l'espace aérien

        public int X => _x;
        public int Y => _y;

        public Charger(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // De manière graphique : un rond de 20 pixels de diamètre
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawEllipse(_chargerBrush, _x - SIZE / 2, _y - SIZE / 2, SIZE, SIZE);
        }
    }
}
