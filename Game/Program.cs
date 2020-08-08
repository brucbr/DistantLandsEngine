using SDL2;

namespace Game
{
    class Program
    {
        public static void Main()
        {
            DistantLands.Graphics.Window win = new DistantLands.Graphics.Window(600, 600, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, false, "Testing");
            DistantLands.Objects.Player player = new DistantLands.Objects.Player("assets/player.png", win.Renderer, 0, 0, 32, 32);
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