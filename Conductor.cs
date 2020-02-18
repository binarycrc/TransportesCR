using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class Conductor : Empleado
    {
        int _ruta;

        public Conductor(string identificacion, string papellido, string sapellido)
            : base(identificacion, papellido, sapellido)
        {
        }
        public int ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }
    }
}
