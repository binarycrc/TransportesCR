using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TransportesCR
{
    public class MainMenu
    {
        Camion[] camions = new Camion[20];
        Buseta[] busetas = new Buseta[20];
        Conductor[] conductors = new Conductor[20];
        Administrador[] administradors = new Administrador[20];
        
        int cuentacamion;
        int cuentabuseta;
        int cuentaconductor;
        int cuentaadministrador;
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
                case 2:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ++ Busetas ++ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ++ Conductor ++ ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" ++ Administrador ++ ");
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
                        case 2: menuBuseta(0); return true;
                        case 3: menuConductor(0); return true;
                        case 4: menuAdministrador(0); return true;
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
        #region CAMIONES
        public void menuCamion(int opcmenu)
        {
            ShowMenu(1);
            if (opcmenu == 0)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                if (cuentacamion < camions.Length) { Console.Write(" 1.Registro de Camiones "); }
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
            string placa;
            int modelo;
            int capacidadkilos;
            int capacidadvolumen;
            string capturaentrada;
            int numvalido;
            string opcguardar;
            string opcotro;

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("***   Registro de Camiones   ***");

            Console.WriteLine("Placa: ");
            Console.WriteLine("Modelo: ");
            Console.WriteLine("Capacidad en Kilogramos: ");
            Console.WriteLine("Capacidad en Volumen: ");

            do
            {
                Console.SetCursorPosition(7, 2); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { placa = capturaentrada; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(8, 3); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { modelo = numvalido; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(25, 4); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { capacidadkilos = numvalido; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(22, 5); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { capacidadvolumen = numvalido; break; }
            } while (true);

            do
            {
                Console.Write("Guardar registro ? Si (s) or No (n): ");
                opcguardar = Console.ReadLine();
                var opcguardarLower = opcguardar?.ToLower();
                if ((opcguardarLower == "s") || (opcguardarLower == "n")) { break; }
            } while (true);

            if (opcguardar == "s")
            {
                Camion camion = new Camion(placa, modelo);
                camion.capacidadkilos = capacidadkilos;
                camion.capacidadvolumen = capacidadvolumen;
                guardaCamion(camion);
                camion = null;
            }

            if (cuentacamion < camions.Length)
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Registrar otro camion ? Si (s) or No (n): ");
                    opcotro = Console.ReadLine();
                    var opcotroLower = opcotro?.ToLower();
                    if ((opcotroLower == "s") || (opcotroLower == "n")) { break; }
                } while (true);
                if (opcotro == "s")
                {
                    menuCamion(1);
                    registroCamion();
                }
                else
                {
                    ShowMenu(1);
                    menuCamion(0);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Maximo de camiones registrados, No se pueden registrar mas camiones!");
                Console.Write("Presione Enter para continuar");
                Console.ReadLine();
                ShowMenu(1);
                menuCamion(0);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void verCamion()
        {
            ShowMenu(1);
            //                 12345678901234567890123456789012345678901234567890123456789012345678901234567890
            Console.WriteLine();
            Console.WriteLine("Placa               Modelo              Cap Kilos           Cap Vol");
            foreach (Camion lineacamion in camions)
            {
                if (lineacamion != null)
                {
                    Console.Write(lineacamion.Placa.ToString().Trim() + new string(' ', 20 - lineacamion.Placa.ToString().Trim().Length));
                    Console.Write(lineacamion.Modelo.ToString().Trim() + new string(' ', 20 - lineacamion.Modelo.ToString().Trim().Length));
                    Console.Write(lineacamion.capacidadkilos.ToString().Trim() + new string(' ', 20 - lineacamion.capacidadkilos.ToString().Trim().Length));
                    Console.Write(lineacamion.capacidadvolumen.ToString().Trim() + new string(' ', 20 - lineacamion.capacidadvolumen.ToString().Trim().Length));
                }
            }
            Console.WriteLine();
            Console.Write("Presione Enter para continuar");
            Console.ReadLine();
        }
        public void guardaCamion(Camion camion)
        {
            cuentacamion = 0;
            foreach (Camion cadacamion in camions) { if (cadacamion != null) { cuentacamion++; } }
            if (cuentacamion < camions.Length)
            {
                camions[cuentacamion] = camion;
                cuentacamion++;
                ShowMenu(1);
                menuCamion(1);
            }
        }
        #endregion CAMIONES

        #region BUSETAS
        public void menuBuseta(int opcmenu)
        {
            ShowMenu(2);
            if (opcmenu == 0)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                if (cuentacamion < camions.Length) { Console.Write(" 1.Registro de Busetas "); }
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
                            menuBuseta(1);
                            registroBuseta();
                            break;
                        case 2:
                            ShowMenu(2);
                            menuBuseta(1);
                            verBuseta();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta!");
                }
            }
        }
        public void registroBuseta()
        {
            string placa;
            int modelo;
            int capacidadpasajeros;
            string capturaentrada;
            int numvalido;
            string opcguardar;
            string opcotro;

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("***   Registro de Buseta   ***");

            Console.WriteLine("Placa: ");
            Console.WriteLine("Modelo: ");
            Console.WriteLine("Capacidad de Pasajeros: ");

            do
            {
                Console.SetCursorPosition(7, 2); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { placa = capturaentrada; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(8, 3); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { modelo = numvalido; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(25, 4); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { capacidadpasajeros = numvalido; break; }
            } while (true);

            do
            {
                Console.Write("Guardar registro ? Si (s) or No (n): ");
                opcguardar = Console.ReadLine();
                var opcguardarLower = opcguardar?.ToLower();
                if ((opcguardarLower == "s") || (opcguardarLower == "n")) { break; }
            } while (true);

            if (opcguardar == "s")
            {
                Buseta buseta = new Buseta(placa, modelo);
                buseta.capacidadpasajeros = capacidadpasajeros;
                guardaBuseta(buseta);
                buseta = null;
            }

            if (cuentabuseta < busetas.Length)
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Registrar otra buseta ? Si (s) or No (n): ");
                    opcotro = Console.ReadLine();
                    var opcotroLower = opcotro?.ToLower();
                    if ((opcotroLower == "s") || (opcotroLower == "n")) { break; }
                } while (true);
                if (opcotro == "s")
                {
                    menuBuseta(1);
                    registroBuseta();
                }
                else
                {
                    ShowMenu(1);
                    menuBuseta(0);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Maximo de busetas registrados, No se pueden registrar mas busetas!");
                Console.Write("Presione Enter para continuar");
                Console.ReadLine();
                ShowMenu(1);
                menuBuseta(0);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void verBuseta()
        {
            ShowMenu(2);
            //                 12345678901234567890123456789012345678901234567890123456789012345678901234567890
            Console.WriteLine();
            Console.WriteLine("Placa                     Modelo                     Cap Pasajeros             ");
            foreach (Buseta lineabuseta in busetas)
            {
                if (lineabuseta != null)
                {
                    Console.Write(lineabuseta.Placa.ToString().Trim() + new string(' ', 26 - lineabuseta.Placa.ToString().Trim().Length));
                    Console.Write(lineabuseta.Modelo.ToString().Trim() + new string(' ', 27 - lineabuseta.Modelo.ToString().Trim().Length));
                    Console.Write(lineabuseta.capacidadpasajeros.ToString().Trim() + new string(' ', 27 - lineabuseta.capacidadpasajeros.ToString().Trim().Length));
                }
            }
            Console.WriteLine();
            Console.Write("Presione Enter para continuar");
            Console.ReadLine();
        }
        public void guardaBuseta(Buseta buseta)
        {
            cuentabuseta = 0;
            foreach (Buseta cadabuseta in busetas) { if (cadabuseta != null) { cuentabuseta++; } }
            if (cuentabuseta < busetas.Length)
            {
                busetas[cuentabuseta] = buseta;
                cuentabuseta++;
                ShowMenu(2);
                menuBuseta(1);
            }
        }
        #endregion BUSETAS

        #region CONDUTORES
        public void menuConductor(int opcmenu)
        {
            ShowMenu(3);
            if (opcmenu == 0)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                if (cuentacamion < camions.Length) { Console.Write(" 1.Registro de Conductor "); }
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
                            menuConductor(1);
                            registroConductor();
                            break;
                        case 2:
                            ShowMenu(2);
                            menuConductor(1);
                            verConductor();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta!");
                }
            }
        }
        public void registroConductor()
        {
            string identificacion;
            string papellido;
            string sapellido;
            int ruta;
            string capturaentrada;
            int numvalido;
            string opcguardar;
            string opcotro;

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("***   Registro de Conductor   ***");

            Console.WriteLine("Identificacion: ");
            Console.WriteLine("Primer Apellido: ");
            Console.WriteLine("Segundo Apellido: ");
            Console.WriteLine("Ruta: ");

            do
            {
                Console.SetCursorPosition(7, 2); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { identificacion = capturaentrada; break; }
            } while (true);
            do
            {
                Console.SetCursorPosition(7, 3); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { papellido = capturaentrada; break; }
            } while (true);
            do
            {
                Console.SetCursorPosition(7, 4); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { sapellido = capturaentrada; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(8, 5); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { ruta = numvalido; break; }
            } while (true);

            do
            {
                Console.Write("Guardar registro ? Si (s) or No (n): ");
                opcguardar = Console.ReadLine();
                var opcguardarLower = opcguardar?.ToLower();
                if ((opcguardarLower == "s") || (opcguardarLower == "n")) { break; }
            } while (true);

            if (opcguardar == "s")
            {
                Conductor conductor= new Conductor(identificacion, papellido, sapellido);
                conductor.ruta = ruta;
                guardaConductor(conductor);
                conductor = null;
            }

            if (cuentaconductor < conductors.Length)
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Registrar otro conductor ? Si (s) or No (n): ");
                    opcotro = Console.ReadLine();
                    var opcotroLower = opcotro?.ToLower();
                    if ((opcotroLower == "s") || (opcotroLower == "n")) { break; }
                } while (true);
                if (opcotro == "s")
                {
                    menuConductor(1);
                    registroConductor();
                }
                else
                {
                    ShowMenu(3);
                    menuConductor(0);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Maximo de conductores registrados, No se pueden registrar mas conductores!");
                Console.Write("Presione Enter para continuar");
                Console.ReadLine();
                ShowMenu(3);
                menuBuseta(0);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void verConductor()
        {
            ShowMenu(3);
            //                 12345678901234567890123456789012345678901234567890123456789012345678901234567890
            Console.WriteLine();
            Console.WriteLine("Identificacion      Primer Apellido     Segundo Apellido    Ruta                ");
            foreach (Conductor lineaconductor in conductors)
            {
                if (lineaconductor != null)
                {
                    Console.Write(lineaconductor.Identificacion.ToString().Trim() + new string(' ', 20 - lineaconductor.Identificacion.ToString().Trim().Length));
                    Console.Write(lineaconductor.PApellido.ToString().Trim() + new string(' ', 20 - lineaconductor.PApellido.ToString().Trim().Length));
                    Console.Write(lineaconductor.SApellido.ToString().Trim() + new string(' ', 20 - lineaconductor.SApellido.ToString().Trim().Length));
                    Console.Write(lineaconductor.ruta.ToString().Trim() + new string(' ', 20 - lineaconductor.ruta.ToString().Trim().Length));
                }
            }
            Console.WriteLine();
            Console.Write("Presione Enter para continuar");
            Console.ReadLine();
        }
        public void guardaConductor(Conductor conductor)
        {
            cuentaconductor = 0;
            foreach (Conductor cadaconductor in conductors) { if (cadaconductor != null) { cuentaconductor++; } }
            if (cuentaconductor < conductors.Length)
            {
                conductors[cuentaconductor] = conductor;
                cuentaconductor++;
                ShowMenu(3);
                menuConductor(1);
            }
        }
        #endregion CONDUCTORES

        #region ADMINISTRADORES
        public void menuAdministrador(int opcmenu)
        {
            ShowMenu(4);
            if (opcmenu == 0)
            {
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                if (cuentaadministrador < administradors.Length) { Console.Write(" 1.Registro de Administrador "); }
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
                            ShowMenu(4);
                            menuAdministrador(1);
                            registroAdministrador();
                            break;
                        case 2:
                            ShowMenu(4);
                            menuAdministrador(1);
                            verAdministrador();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta!");
                }
            }
        }
        public void registroAdministrador()
        {
            string identificacion;
            string papellido;
            string sapellido;
            int grupo;
            string capturaentrada;
            int numvalido;
            string opcguardar;
            string opcotro;

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("***   Registro de Administrador   ***");

            Console.WriteLine("Identificacion: ");
            Console.WriteLine("Primer Apellido: ");
            Console.WriteLine("Segundo Apellido: ");
            Console.WriteLine("Grupo: ");

            do
            {
                Console.SetCursorPosition(7, 2); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { identificacion = capturaentrada; break; }
            } while (true);
            do
            {
                Console.SetCursorPosition(7, 3); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { papellido = capturaentrada; break; }
            } while (true);
            do
            {
                Console.SetCursorPosition(7, 4); capturaentrada = Console.ReadLine();
                if (Regex.IsMatch(capturaentrada, "^[a-zA-Z0-9]*$")) { sapellido = capturaentrada; break; }
            } while (true);

            do
            {
                Console.SetCursorPosition(8, 5); capturaentrada = Console.ReadLine();
                if (int.TryParse(capturaentrada, out numvalido)) { grupo = numvalido; break; }
            } while (true);

            do
            {
                Console.Write("Guardar registro ? Si (s) or No (n): ");
                opcguardar = Console.ReadLine();
                var opcguardarLower = opcguardar?.ToLower();
                if ((opcguardarLower == "s") || (opcguardarLower == "n")) { break; }
            } while (true);

            if (opcguardar == "s")
            {
                Administrador Administrador = new Administrador(identificacion, papellido, sapellido);
                Administrador.grupo = grupo;
                guardaAdministrador(Administrador);
                Administrador = null;
            }

            if (cuentaadministrador < administradors.Length)
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Registrar otro Administrador ? Si (s) or No (n): ");
                    opcotro = Console.ReadLine();
                    var opcotroLower = opcotro?.ToLower();
                    if ((opcotroLower == "s") || (opcotroLower == "n")) { break; }
                } while (true);
                if (opcotro == "s")
                {
                    menuAdministrador(2);
                    registroAdministrador();
                }
                else
                {
                    ShowMenu(4);
                    menuAdministrador(0);
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Maximo de Administradores registrados, No se pueden registrar mas Administradores!");
                Console.Write("Presione Enter para continuar");
                Console.ReadLine();
                ShowMenu(4);
                menuAdministrador(0);
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void verAdministrador()
        {
            ShowMenu(4);
            //                 12345678901234567890123456789012345678901234567890123456789012345678901234567890
            Console.WriteLine();
            Console.WriteLine("Identificacion      Primer Apellido     Segundo Apellido    Grupo               ");
            foreach (Administrador lineaAdministrador in administradors)
            {
                if (lineaAdministrador != null)
                {
                    Console.Write(lineaAdministrador.Identificacion.ToString().Trim() + new string(' ', 20 - lineaAdministrador.Identificacion.ToString().Trim().Length));
                    Console.Write(lineaAdministrador.PApellido.ToString().Trim() + new string(' ', 20 - lineaAdministrador.PApellido.ToString().Trim().Length));
                    Console.Write(lineaAdministrador.SApellido.ToString().Trim() + new string(' ', 20 - lineaAdministrador.SApellido.ToString().Trim().Length));
                    Console.Write(lineaAdministrador.grupo.ToString().Trim() + new string(' ', 20 - lineaAdministrador.grupo.ToString().Trim().Length));
                }
            }
            Console.WriteLine();
            Console.Write("Presione Enter para continuar");
            Console.ReadLine();
        }
        public void guardaAdministrador(Administrador administrador)
        {
            cuentaadministrador = 0;
            foreach (Administrador cadaadministrador in administradors) { if (cadaadministrador != null) { cuentaadministrador++; } }
            if (cuentaadministrador < administradors.Length)
            {
                administradors[cuentaadministrador] = administrador;
                cuentaadministrador++;
                ShowMenu(4);
                menuAdministrador(1);
            }
        }
        #endregion ADMINISTRADORES

        public void menuRegistros() { }

    }
}
