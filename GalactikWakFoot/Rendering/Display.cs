using GalactikWakFoot.GameSystem.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalactikWakFoot.Rendering
{
    public class Display
    {
        DisplayGame displayGame;
        DisplayMenu displayMenu;

        public Display(int Width, int Height, MapManager mapManager)
        {
            displayGame = new DisplayGame(Width, Height, mapManager);
            displayMenu = new DisplayMenu(Width, Height);
        }

        public void Load()
        {
            displayMenu.Load();
            //displayGame.Load();
        }

        public void Render()
        {
            displayMenu.Load();
            //displayGame.Render();
        }
    }
}
