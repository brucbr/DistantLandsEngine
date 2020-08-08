#region Using Statements
using System;
using SDL2;
using DistantLands.Objects;
#endregion

namespace DistantLands.Graphics
{
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
    }
    #endregion
}
