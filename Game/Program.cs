using SDL2;
using DistantLands.Graphics;
using DistantLands.Objects;

namespace Game
{
    class Program
    {
        static void Main() {
            var win = new Window(600, 600, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, false, "Testing");
            var player = new Player("assets/player.png", win.Renderer, 0, 0, 32, 32);
            while (win.Running)
            {
                win.FrameCheck();
                win.HandleEvents();
                win.Update(player);
                win.Render(player);
            }
            win.Clean();
        }
    }
}