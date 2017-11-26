using System.Drawing;

namespace timbiriche
{
    public class Cuadro
    {
        Color color;
        Point point;
        Size Size;
        bool barco, ataque;
        public Cuadro(Color c, Point p, Size s)
        {
            color = c;
            point = p;
            Size = s;
        }

        public Color C { get => color; set => color = value; }
        public Point P { get => point; set => point = value; }
        public Size S { get => Size; set => Size = value; }
        public bool Barco { get => barco; set => barco = value; }
        public bool Ataque { get => ataque; set => ataque = value; }
    }
}
