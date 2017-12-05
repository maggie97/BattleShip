using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    public class Barco
    {
        public Bitmap b, frameAct, barco, ataque; //frame act
        Size size;
        public Explosion exp;
        int tipoBarco, idBarco,elapsedFrames = 0;
        private int numFrames = 10, index = 0;
        bool horiz = false;

        public Barco(Size s)
        { 
            //b = new Bitmap(); // cambio por aguita 
            //barco = new Bitmap();
            //ataque = new Bitmap(); // dependen de que lugarito tengan 
            //exp = new Explosion();
            size = s;
            Aguita();
            frameAct = b;
            //b = new Bitmap(Properties.Resources.bomba, size);
        }
        public void Load(int tipo, int id, bool horizontal)
        {
            tipoBarco = tipo;
            idBarco = id + 1;
            horiz = horizontal;
            //if(horizontal)
            switch (tipoBarco)
            {
                case 1:
                    BarcoT1();
                    break;
                case 2:
                    BarcoT2();
                    break;
                case 3:
                    BarcoT3();
                    break;
            }
            Orientacion();
            frameAct = barco;

        }
        public void Load(int tipo)
        {
            if(tipo == 0)
                Aguita();
            Tipo = 0;
            frameAct = b;
        }
        public void Orientacion()
        {
            if (horiz)
            {
                barco.RotateFlip(RotateFlipType.Rotate90FlipXY);
            }
        }
        private void BarcoT3()
        {
            switch (idBarco)
            {
                case 1:
                    //barco.Add(new Bitmap(Properties.Resources.barco5_1_, size));
                    barco = new Bitmap(Properties.Resources.barco5_1_, size);
                    break;
                case 2:
                    barco = new Bitmap(Properties.Resources.barco5_2_, size);
                    break;
                case 3:
                    barco = new Bitmap(Properties.Resources.barco5_3_, size);
                    break;
                case 4:
                    barco = new Bitmap(Properties.Resources.barco5_4_, size);
                    break;
                case 5:
                    barco = new Bitmap(Properties.Resources.barco5_5_, size);
                    break;
            }
        }
        private void BarcoT2()
        {
            switch (idBarco)
            {
                case 1:
                    barco = new Bitmap(Properties.Resources.barco2_1_, size);
                    break;
                case 2:
                    barco = new Bitmap(Properties.Resources.barco2_2_, size);
                    break;
                case 3:
                    barco = new Bitmap(Properties.Resources.barco2_3_, size);
                    break;
            }
        }
        private void BarcoT1(){ barco = new Bitmap(Properties.Resources.baarco3_0_, size); }
        public void Ataque()
        {
            switch (tipoBarco)
            {
                case 1:
                    BarcoMoridoT1();
                    break;
                case 2:
                    BarcoMoridoT2();
                    break;
                case 3:
                    AtaqueBarcoT3();
                    break;
            }
            frameAct = ataque;
        }
        private void AtaqueBarcoT3()
        {
            switch (idBarco)
            {
                case 1:
                    //barco.Add(new Bitmap(Properties.Resources.barco5_1_, size));
                    ataque = new Bitmap(Properties.Resources.barcoMorido3_1_, size);
                    break;
                case 2:
                    ataque = new Bitmap(Properties.Resources.barcoMorido3_2_, size);
                    break;
                case 3:
                    ataque = new Bitmap(Properties.Resources.barcoMorido3_3_, size);
                    break;
                case 4:
                    ataque = new Bitmap(Properties.Resources.barcoMorido3_4_, size);
                    break;
                case 5:
                    ataque = new Bitmap(Properties.Resources.barcoMorido3_5_, size);
                    break;
            }
        }
        private void BarcoMoridoT2()
        {
            switch (idBarco)
            {
                case 1:
                    ataque = new Bitmap(Properties.Resources.barcoMorido2_1_, size);
                    break;
                case 2:
                    ataque = new Bitmap(Properties.Resources.barcoMorido2_2_, size);
                    break;
                case 3:
                    ataque = new Bitmap(Properties.Resources.barcoMorido2_3_, size);
                    break;
            }
        }
        private void BarcoMoridoT1() { ataque = new Bitmap(Properties.Resources.barcoMorido1, size); }
        private void Aguita() { b = new Bitmap(Properties.Resources.agua, size); }
        public void AtaqueAgua()
        {
            ataque = new Bitmap(Properties.Resources.AtaqueAgua, size);
            frameAct = ataque;
        }
        public Bitmap frameActual{ get { return frameAct; }}
        public int Tipo { get => tipoBarco; set => tipoBarco = value; }
        public int IdB { get => idBarco; set => idBarco = value; }
    }
}
