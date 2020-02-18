using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class Buseta : Vehiculo
    {
        int _capacidadpasajeros;
        public Buseta(string placa, int modelo)
            : base(placa, modelo)
        {
        }
        public int capacidadpasajeros
        {
            get { return _capacidadpasajeros; }
            set { _capacidadpasajeros = value; }
        }

    }
}
