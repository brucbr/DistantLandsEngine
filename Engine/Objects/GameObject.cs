using System;
using System.Diagnostics;
using DistantLands.Graphics;
using DistantLands.Input;
using SDL2;

namespace DistantLands.Objects
{
    #region GameObject class
    /// <summary>
    ///    Class for all game objects, regardless of their type. Manages rendering, placement on screen and textures
    /// </summary>
    public class GameObject
    {
        int _xPos;
        int _yPos;
        IntPtr _objTexture;
        private SDL.SDL_Rect _srect, _drect;
        public GameObject(string textureSheetPath, IntPtr ren, int xPos, int yPos, int refH, int refW)
        {
            // Set global x and y positions
            _xPos = xPos;
            _yPos = yPos;
            // Create texture
            Texture textureManager = new Texture();
            _objTexture = textureManager.Set(textureSheetPath, ren);

            // Height and width to take from the sprite sheet
            _srect.h = refH;
            _srect.w = refW;
            // Scale the size of the sprite to twice its normal size. Temporary!
            _drect.w = _srect.w * 2;
            _drect.h = _srect.h * 2;

        }

        /// <summary>
        ///   Updates x and y coordinates for objects, however doesn't change the actual position yet. 
        /// </summary>
        public void UpdatePos(int xObjPos, int yObjPos)
        {
            _xPos += xObjPos;
            _yPos -= yObjPos;
        }
        /// <summary>
        ///    Updates Destination rectangle to reflect new x and  y values for game object.
        /// </summary>
        public void UpdateGraphical()
        {
            _drect.x = _xPos;
            _drect.y = _yPos;
        }
        
        /// <summary>
        ///    Cause game object to render in next render update.
        /// </summary>
        public void Render(IntPtr ren)
        {
            SDL.SDL_RenderCopy(ren, _objTexture, ref _srect, ref _drect);
        }
    }
    #endregion
}
