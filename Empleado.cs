using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class Empleado
    {
        string _identificacion;
        string _papellido;
        string _sapellido;
        public string Identificacion { get { return _identificacion; } set { _identificacion = value; } }
        public string PApellido { get { return _papellido; } set { _papellido = value; } }
        public string SApellido { get { return _sapellido; } set { _sapellido = value; } }
        public Empleado(string identificacion, string papellido, string sapellido)
        {
            _identificacion = identificacion;
            _papellido = papellido;
            _sapellido = sapellido;
        }
    }
}
