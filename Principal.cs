using System;

namespace TransportesCR
{
    class Principal
    {
        static void Main(string[] args)
        {
            try
            {
                //configurar tama;o de la pantalla
                Console.SetWindowSize(80, 40);

                //configurar buffer de la consola
                Console.SetBufferSize(80, 80);

                MainMenu mainmenu = new MainMenu();
                bool showMenu = true;
                do
                {
                    showMenu = mainmenu.ShowMenu(0);
                } while (showMenu);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Error: "+ex.Message);
                throw;
            }
        }
    }
}
