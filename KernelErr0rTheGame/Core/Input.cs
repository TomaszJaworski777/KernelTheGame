using KernelErr0rTheGame.Enums;
using KernelErr0rTheGame.Structures;
using SDL2;
using System.Collections.Generic;

namespace KernelErr0rTheGame.InputSystem
{
    public static class Input
    {
        private static readonly HashSet<SDL.SDL_Keycode> _keysDown = new HashSet<SDL.SDL_Keycode>();
        private static readonly HashSet<byte> _mouseButtonsDown = new HashSet<byte>();

        private static SDL.SDL_MouseMotionEvent _mouseMotionEvent;
        private static int _mouseWheelDirection;

        public static SDL.SDL_Keycode UpKey = SDL.SDL_Keycode.SDLK_w;
        public static SDL.SDL_Keycode DownKey = SDL.SDL_Keycode.SDLK_s;
        public static SDL.SDL_Keycode RightKey = SDL.SDL_Keycode.SDLK_d;
        public static SDL.SDL_Keycode LeftKey = SDL.SDL_Keycode.SDLK_a;

        public static bool AnyKeyDown => _keysDown.Count > 0;
        public static bool AnyMouseButtonDown => _mouseButtonsDown.Count > 0;
        public static bool AnyMouseMotion => _mouseMotionEvent.type != SDL.SDL_EventType.SDL_FIRSTEVENT;
        public static bool AnyScrollWheenMove => _mouseWheelDirection != 0;

        public static int ScrollWheelDirection => -(_mouseWheelDirection > 1 ? -1 : _mouseWheelDirection); 

        public static bool IsKeyDown(SDL.SDL_Keycode key) => _keysDown.Contains(key);
        public static bool IsMouseButtonDown(MouseButton button) => _mouseButtonsDown.Contains((byte)button);

        public static Vector2 GetMovementDirection()
        {
            var upAxis = 0;
            if (IsKeyDown(UpKey)) upAxis--;
            if (IsKeyDown(DownKey)) upAxis++;

            var rightAxis = 0;
            if (IsKeyDown(RightKey)) rightAxis++;
            if (IsKeyDown(LeftKey)) rightAxis--;

            return new Vector2(rightAxis, upAxis).Normalized;
        }

        public static void HandleEvent(SDL.SDL_Event inputEvent)
        {
            _mouseMotionEvent = new SDL.SDL_MouseMotionEvent();
            _mouseWheelDirection = 0;

            switch (inputEvent.type)
            {
                case SDL.SDL_EventType.SDL_KEYDOWN:             
                    _keysDown.Add(inputEvent.key.keysym.sym); 
                    break;
                case SDL.SDL_EventType.SDL_KEYUP:               
                    RemoveKey(inputEvent.key.keysym.sym); 
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONDOWN:     
                    _mouseButtonsDown.Add(inputEvent.button.button); 
                    break;
                case SDL.SDL_EventType.SDL_MOUSEBUTTONUP:       
                    RemoveMouseButton(inputEvent.button.button); 
                    break;
                case SDL.SDL_EventType.SDL_MOUSEMOTION:         
                    _mouseMotionEvent = inputEvent.motion; 
                    break;
                case SDL.SDL_EventType.SDL_MOUSEWHEEL:
                    _mouseWheelDirection = (int)inputEvent.wheel.direction;
                    break;
            }
        }

        private static void RemoveKey(SDL.SDL_Keycode key)
        {
            if (_keysDown.Contains(key)) 
                _keysDown.Remove(key);
        }

        private static void RemoveMouseButton(byte button)
        {
            if (_mouseButtonsDown.Contains(button)) 
                _mouseButtonsDown.Remove(button);
        }
    }
}
