using KernelErr0rTheGame.GameEnviroment;
using KernelErr0rTheGame.Structures;
using SDL2;
using System;
using System.Diagnostics;

namespace KernelErr0rTheGame.Core
{
    class GameWindow
    {
        private IntPtr _window;
        private Render _render;
        private float _frameTime;

        private WindowEventHandler _windowEventHandler;

        public void Initialize()
        {
            _window = SDL.SDL_CreateWindow("KernelErr0r The Game", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 1280, 720, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            if (_window == IntPtr.Zero)
                throw new Exception();

            _windowEventHandler = new WindowEventHandler();

            _render = new Render(_window);
            _render.Initalize();

            SceneManager.LoadNewScene(new Game());
        }

        public void FrameLoop()
        {
            var stopwatch = new Stopwatch();
            while (!_windowEventHandler.QuitCommand)
            {
                stopwatch.Start();
                _windowEventHandler.HandleEvents();
                _render.Clear();
                SceneManager.Scene.UpdateGameObjects(_frameTime);
                SceneManager.Scene.DrawGameObjects(_render);
                _render.Display();
                stopwatch.Stop();
                _frameTime = stopwatch.ElapsedTicks / 10000000f;
                stopwatch.Reset();
            }

            _render.Destroy();
            SDL.SDL_DestroyWindow(_window);
            SceneManager.DestroyScene();
        }
    }
}
