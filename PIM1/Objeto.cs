using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM1
{
    class Objeto
    {
        public int valor { get; set; }
        public int anterior { get; set; }
        public int posterior { get; set; }

        // constructor
        public Objeto(int ant, int val, int post)
        {
            valor = val;
            anterior = ant;
            posterior = post;
        }

        // mapeo los valores con los colores
        public string getColor(int val)
        {
            switch (val)
            {
                case 1:
                    return "ROJO";
                case 2:
                    return "VERDE";
                case 3:
                    return "AMARILLO";
                case 4:
                    return "AZUL";
                default:
                    return "ERROR";
            }
        }
    }
}
