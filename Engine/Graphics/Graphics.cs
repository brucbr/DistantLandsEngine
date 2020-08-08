using System;
using SDL2;
using DistantLands.Objects;

namespace DistantLands.Graphics
{
    #region Window Manager
    public class Window
    {
        public IntPtr Win;
        public IntPtr Renderer;
        public Array Objects;
        const int Fps = 20;
        const int FrameDelay = 100 / Fps;
        uint _frameStart;
        int _frameTime;
        public bool Running;
        SDL.SDL_WindowFlags _flags;
        public Window(int width, int height, int xPos, int yPos, bool fullscreen, string title)
        {
            if (fullscreen) { _flags = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE; }
            Running = false;
            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) == 0)
            {
                Win = SDL.SDL_CreateWindow(title,
                    xPos,
                    yPos,
                    width,
                    height,
                    _flags
                    );
                Renderer = SDL.SDL_CreateRenderer(Win, -1, 0);
                // Check if window and render are still equal to null (IntPtr.Zero)
                if (Win != IntPtr.Zero)
                {
                    // Window true, check render
                    if (Renderer != IntPtr.Zero)
                    { Running = true; SDL.SDL_SetRenderDrawColor(Renderer, 0, 255, 0, 255); }
                    else { Running = false; }
                }
                else { Running = false; }

            }
            else { Running = false; }
        }
        public void FrameCheck()
        {
            _frameStart = SDL.SDL_GetTicks();
            _frameTime = Convert.ToInt32(SDL.SDL_GetTicks()) - Convert.ToInt32(_frameStart);
            if (FrameDelay > _frameTime) { SDL.SDL_Delay(Convert.ToUInt32(FrameDelay) - Convert.ToUInt32(_frameTime)); }
        }
        public void HandleEvents()
        {
        }
        public void Update(params GameObject[] objects)
        {
            foreach (GameObject obj in objects)
            {
                obj.UpdateGraphical();
            }
        }
        public void Update(params Player[] objects)
        {
            foreach (Player obj in objects)
            {
                obj.PlayerInput.Update();
                obj.Update();
                obj.PlayerInput.QuitCheck();
            }
        }
        public void Render(params GameObject[] objects)
        {
            SDL.SDL_RenderClear(Renderer);
            foreach (GameObject obj in objects)
            {
                obj.Render(Renderer);
            }
            SDL.SDL_RenderPresent(Renderer);
        }
        public void Clean()
        {
            SDL.SDL_DestroyWindow(Win);
            SDL.SDL_DestroyRenderer(Renderer);
            SDL.SDL_Quit();
        }
    }
    #endregion

    #region Texture
    public class Texture
    {
        public IntPtr Set(string path, IntPtr renderer)
        {
            IntPtr texture;
            IntPtr surface;
            surface = SDL_image.IMG_Load(path);
            texture = SDL.SDL_CreateTextureFromSurface(renderer, surface);
            return texture;
        }
        #endregion
    }
}
