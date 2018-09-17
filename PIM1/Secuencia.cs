using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM1
{
    // clase que se encarga de cargar las secuencias
    class Secuencia
    {
        public List<Objeto> Objetos = new List<Objeto>();
        public int Juego { get; set; }

        // Contructor
        public Secuencia(int juego) => Juego = juego;

        // método público para agregar objetos a la secuencia
        public void AddObjeto(Objeto objeto) => Objetos.Add(objeto);

        // método que se encarga de agregar un valor nuevo y modificar la cadena
        public void AddObjetoByVal(int val)
        {
            if (Objetos.Count > 0)
            {
                Objeto lastObjeto = Objetos.Last();
                int ant = Convert.ToInt32(lastObjeto.Valor);
                int id = Convert.ToInt32(lastObjeto.Id) + 1;

                lastObjeto.Posterior = val;
                Objeto nuevoObjeto = new Objeto(id, ant, val, 0);
                AddObjeto(nuevoObjeto);
            } else
            {
                Objeto nuevoObjeto = new Objeto(1, 0, val, 0);
                AddObjeto(nuevoObjeto);
            }
            
        }

        public List<Objeto> GetObjetos() => Objetos;
    }
}
