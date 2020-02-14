using System;
using System.Collections.Generic;
using System.Text;

namespace TransportesCR
{
    public class MainMenu
    {
        Camion[] camions = new Camion[20];
        Camion camion;
        Administrador[] administdors = new Administrador[20];
        Conductor[] conductors = new Conductor[20];

        //Conductor conductorA = new Conductor();
        //conductors[contconductor++] = conductorA;

        public bool ShowMenu(int opcmenu) 
        {
            Console.Clear();
            switch (opcmenu)
            {
                case 1:
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ++ Camiones ++ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            if (opcmenu == 0) {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" 1.Camion ");
                Console.Write(" 2.Buseta ");
                Console.Write(" 3.Conductor ");
                Console.Write(" 4.Administrador ");
                Console.Write(" 5.Registros ");
                Console.Write(" 9.SALIR ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                Console.Write("Seleccione una opcion del menu: ");
                string opciondemenu = Console.ReadLine();
                int validanumero;
                bool resultadovalidanumero = Int32.TryParse(opciondemenu, out validanumero);
                if (resultadovalidanumero)
                {
                    switch (validanumero)
                    {
                        case 1: menuCamion(0); return true;
                        case 2: menuBuseta(); return true;
                        case 3: menuConductor(); return true;
                        case 4: menuAdministrador(); return true;
                        case 5: menuRegistros(); return true;
                        case 9: Environment.Exit(0); return false;
                        default: return true;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta!");
                    return true;
                }
            }
            else { return true; }
        }
        public void menuCamion(int opcmenu)
        {
            ShowMenu(1);
            if (opcmenu == 0)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" 1.Registro de Camiones ");
                Console.Write(" 2.Todos los registros ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                Console.Write("Seleccione una opcion del menu: ");
                string opciondemenu = Console.ReadLine();
                int validanumero;
                bool resultadovalidanumero = Int32.TryParse(opciondemenu, out validanumero);
                if (resultadovalidanumero)
                {
                    switch (validanumero)
                    {
                        case 1:
                            ShowMenu(1);
                            menuCamion(1); 
                            registroCamion(); 
                            break;
                        case 2:
                            ShowMenu(1);
                            menuCamion(1); 
                            verCamion(); 
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta!");
                }
            }
        }

        public void registroCamion()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(); Console.Write("***   Registro de Camiones   ***");
            Console.WriteLine(); Console.Write("Placa: "); string placa = Console.ReadLine();
            Console.Write("Modelo: "); string modelo = Console.ReadLine();
            Console.Write("Capacidad en Kilogramos: "); string capacidadkilos = Console.ReadLine();
            Console.Write("Capacidad en Volumen: "); string capacidadvolumen = Console.ReadLine();

            string opcguardar;
            do
            {
                Console.Write("Guardar registro ? Si (s) or No (n): ");
                opcguardar = Console.ReadLine();
                var opcguardarLower = opcguardar?.ToLower();
                if ((opcguardarLower == "s") || (opcguardarLower == "n")) { break; }
            } while (true);
            if (opcguardar == "s")
            {
                camion.Placa = placa;
                camion.Modelo = modelo;
                camion.capacidadkilos = capacidadkilos;
                camion.capacidadvolumen = capacidadvolumen;
                guardaCamion(); 
            }

            string opcotro;
            do
            {
                Console.Write("Registrar otro camion ? Si (s) or No (n): ");
                opcotro = Console.ReadLine();
                var opcotroLower = opcotro?.ToLower();
                if ((opcotroLower == "s") || (opcotroLower == "n")) { break; }
            } while (true);
            if (opcotro == "s") { registroCamion(); }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void verCamion()
        {
            Console.WriteLine();
            //Camion camion = new Camion();
            foreach (Camion camion in camions )
            {

            }
        }
        public void guardaCamion()
        {
            camions[camions.Length + 1] = camion;
        }

        public void menuBuseta(){}
        public void menuConductor() { }
        public void menuAdministrador() { }
        public void menuRegistros() { }

    }
}
