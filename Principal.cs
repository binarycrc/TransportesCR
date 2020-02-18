using System;
using System.Collections.Generic;

namespace TransportesCR
{
    
    class Principal
    {
        static void Main(string[] args)
        {
            // setting the window size
            Console.SetWindowSize(80, 40);

            // setting buffer size of console 
            Console.SetBufferSize(80, 80);

            MainMenu mainmenu = new MainMenu();
            bool showMenu = true;
            do{
                showMenu = mainmenu.ShowMenu(0);
            } while (showMenu);
        }

        

    }

}
