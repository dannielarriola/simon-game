using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM1
{
    // clase que se encarga de guardar cada objeto de la secuencia
    class Objeto
    {
        public int Valor { get; set; }
        public int Anterior { get; set; }
        public int Posterior { get; set; }
        public int Id { get; set; }

        // constructor
        public Objeto(int id, int ant, int val, int post)
        {
            Id = id;
            Valor = val;
            Anterior = ant;
            Posterior = post;
        }

        // mapeo los valores con los colores
        public Color GetColor(int val)
        {
            switch (val)
            {
                case 1:
                    return Color.Red;
                case 2:
                    return Color.ForestGreen;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.LightSkyBlue;
                default:
                    return Color.Black;
            }
        }
    }
}
