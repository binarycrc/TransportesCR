using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class Camion : Vehiculo
    {
        int _capacidadkilos;
        int _capacidadvolumen;

        public Camion(string placa, int modelo)
            : base(placa, modelo)
        { 
        }
        public int capacidadkilos { 
            get { return _capacidadkilos; }
            set { _capacidadkilos = value; }
        }
        public int capacidadvolumen
        {
            get { return _capacidadvolumen; }
            set { _capacidadvolumen = value; }
        }
    }
}
