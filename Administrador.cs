using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class Administrador : Empleado
    {
        int _grupo;
        public Administrador(string identificacion, string papellido, string sapellido)
            : base(identificacion, papellido, sapellido)
        {
        }
        public int grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }
    }
}
