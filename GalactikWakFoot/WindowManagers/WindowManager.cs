using GalactikWakFoot.GameSystem;
using GalactikWakFoot.Rendering;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using GalactikWakFoot.GameSystem.Map;

namespace GalactikWakFoot.WindowManagers
{
    public class WindowManager : GameWindow
    {
        EventManager eventManager;
        GameLoop gameLoop;
        Display display;

        public WindowManager(int Width, int Height, string Title) : base(Width, Height, GraphicsMode.Default, Title)
        {
            MapManager mapManager = new MapManager("Ressources/Maps/map.json");
            eventManager = new EventManager(mapManager, this);
            gameLoop = new GameLoop(mapManager);
            display = new Display(Width, Height, mapManager);
        }

        protected override void OnLoad(EventArgs e)
        {
            display.Load();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            gameLoop.WinCondition();
            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            display.Render();

            SwapBuffers();
        }
    }
}
