using System;
using System.Collections.Generic;

namespace TransportesCR
{
    
    class Principal
    {
        static void Main(string[] args)
        {
            MainMenu mainmenu = new MainMenu();
            bool showMenu = true;
            do{
                showMenu = mainmenu.ShowMenu(0);
            } while (showMenu);
        }

        

    }

}
