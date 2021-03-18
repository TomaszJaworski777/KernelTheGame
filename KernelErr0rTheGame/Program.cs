using KernelErr0rTheGame.Core;
using SDL2;

namespace KernelErr0rTheGame
{
    private class Program
    {
        private static void Main(string[] args)
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);
            SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_PNG);

            var gameWindow = new GameWindow();
            gameWindow.Initialize();
            gameWindow.FrameLoop();

            SDL_image.IMG_Quit();
            SDL.SDL_Quit();
        }
    }
}
