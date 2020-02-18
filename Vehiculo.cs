using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class Vehiculo
    {
        string _placa;
        int _modelo;
        public string Placa { get { return _placa; } set { _placa = value; } }
        public int Modelo { get { return _modelo; } set { _modelo = value; } }
        public Vehiculo(string placa, int modelo) 
        {
            _placa = placa;
            _modelo = modelo;
        }
    }
}
