using KernelErr0rTheGame.InputSystem;
using SDL2;

namespace KernelErr0rTheGame.Core
{
    public class WindowEventHandler
    {
        public bool QuitCommand = false;

        public void HandleEvents()
        {
            while (SDL.SDL_PollEvent(out var windowEvent) != 0)
            {
                HandleEvent(windowEvent);
                Input.HandleEvent(windowEvent);
            }
        }

        private void HandleEvent(SDL.SDL_Event windowEvent)
        {
            switch (windowEvent.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:                
                    QuitCommand = true; 
                    break;
            }
        }
    }
}
