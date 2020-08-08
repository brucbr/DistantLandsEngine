using SDL2;
namespace DistantLands.Input
{
    public class Input
    {
        private int _vertical, _horizontal;
        private SDL.SDL_Event _e;
        public Input()
        {
            _vertical = 0;
            _horizontal = 0;
        }

        public void Update()
        {
            SDL.SDL_PollEvent(out this._e);
        }
        public void ArrowKeys(out int v, out int h)
        {
            switch (this._e.type)
            {
                case SDL.SDL_EventType.SDL_KEYDOWN:
                    switch (this._e.key.keysym.sym)
                    {
                        case SDL.SDL_Keycode.SDLK_DOWN:
                        case SDL.SDL_Keycode.SDLK_s:
                            this._vertical -= 1;
                            break;
                        case SDL.SDL_Keycode.SDLK_UP:
                        case SDL.SDL_Keycode.SDLK_w:
                            this._vertical += 1;
                            break;
                        case SDL.SDL_Keycode.SDLK_LEFT:
                        case SDL.SDL_Keycode.SDLK_a:
                            this._horizontal -= 1;
                            break;
                        case SDL.SDL_Keycode.SDLK_RIGHT:
                        case SDL.SDL_Keycode.SDLK_d:
                            this._horizontal += 1;
                            break;
                    }
                    this._horizontal = 0;
                    this._vertical = 0;
                    break;
            }

            v = this._vertical;
            h = this._horizontal;
        }

        public void GetKey(out SDL.SDL_Keycode[] key)
        {
            key = null;
        }

        public void QuitCheck()
        {
            switch (this._e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:
                    SDL.SDL_Quit();
                    break;
            }
        }
    }
}