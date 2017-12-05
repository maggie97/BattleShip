using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Cuadro
    {
        Color color;
        Point point;
        Size Size;
        bool barco, ataque;
        int id = -1;
        public Barco ship;

        public Cuadro(Color c, Point p, Size s)
        {
            color = c;
            point = p;
            Size = s;
            barco = ataque = false;
            ship = new Barco(Size);
        }

        public Color C { get => color; set => color = value; }
        public Point P { get => point; set => point = value; }
        public Size S { get => Size; set => Size = value; }
        public bool Barco { get => barco; set => barco = value; }
        public bool Ataque { get => ataque; set => ataque = value; }
    }
}
