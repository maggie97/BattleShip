using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Explosion
    {
        public List<Bitmap> explosion, nada, act;
        int elapsedFrames = 0, numFrames = 10, index = 0;
        public bool cambio;
        public Explosion()
        {
            cambio = false;
            explosion = new List<Bitmap>();
            nada = new List<Bitmap>();
            
            nada.Add(Properties.Resources.explota0);
            explosion.Add(Properties.Resources.explota2);
            explosion.Add(Properties.Resources.explota3);
            explosion.Add(Properties.Resources.explota4);
            explosion.Add(Properties.Resources.explota5);
            explosion.Add(Properties.Resources.explota6);
            explosion.Add(Properties.Resources.explota7);
            explosion.Add(Properties.Resources.explota8);
            explosion.Add(Properties.Resources.explota9);
            explosion.Add(Properties.Resources.explota10);
            explosion.Add(Properties.Resources.explota11);

            act = nada;
        }
        public void Update()
        {
            cambio = false;
            elapsedFrames++;
            if (elapsedFrames == numFrames)
                elapsedFrames = 0;
            else
                return;
            cambio = true;
            index++;
            if (index >= act.Count)
            {
                index = 0;
                SinExplotar();
            }
        }
        public Bitmap frameActual
        {
            get
            {
                if (index >= act.Count) {
                    index = 0;
                    SinExplotar();
                }
                return act[index];
            }
        }
        public void Explota()
        {
            act = explosion;
        }
        public void SinExplotar()
        {
            if (act == explosion)
                act = nada;
        }

    }
}
