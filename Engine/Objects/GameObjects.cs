using System;
using DistantLands.Graphics;
using DistantLands.Input;
using SDL2;

namespace DistantLands.Objects
{
    #region GameObject class
    public class GameObject
    {
        int _xPos;
        int _yPos;
        IntPtr _objTexture;
        SDL.SDL_Rect _srect, _drect;
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

        public void UpdatePos(int xObjPos, int yObjPos)
        {
            _xPos += xObjPos;
            _yPos -= yObjPos;
        }
        public void UpdateGraphical()
        {
            _drect.x = _xPos;
            _drect.y = _yPos;
        }
        public void Render(IntPtr ren)
        {
            SDL.SDL_RenderCopy(ren, _objTexture, ref _srect, ref _drect);
        }
    }
    #endregion

    #region Player Object
    public class Player : GameObject
    {
        int _horizontal, _vertical;
        public GameObject Entity;
        public readonly DistantLands.Input.Input PlayerInput;
        public Player(string textureSheetPath, IntPtr ren, int xPlayPos, int yPlayPos, int refH, int refW) : base(textureSheetPath, ren, xPlayPos, yPlayPos, refH, refW)
        {
            _horizontal = 0; _vertical = 0;
            PlayerInput = new Input.Input();
        }
        
        private void Movement(int vertical, int horizontal, int speed)
        {
            UpdatePos(horizontal * speed, vertical * speed);
        }

        public void Update()
        {
            PlayerInput.ArrowKeys(out this._vertical, out this._horizontal);
            Movement(this._vertical, this._horizontal, speed: 4);
            UpdateGraphical();
        }
    }
    #endregion

    #region EnemyObject

    #endregion 
}
