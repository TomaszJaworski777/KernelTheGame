using System;
using KernelErr0rTheGame.Structures;
using SDL2;

namespace KernelErr0rTheGame.Core
{
    public class Render
    {
        private IntPtr _render;
        private IntPtr _window;
        public static Render reference;

        public Render(IntPtr window)
        {
            _window = window;
            reference = this;
        }

        public void Initalize()
        {
            _render = SDL.SDL_CreateRenderer(_window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            if (_render == IntPtr.Zero)
                throw new Exception();
        }

        public Texture CreateTextureFromFile(string path, int width, int height)
        {
            var texture = new Texture(path, width, height);
            texture.Pointer = SDL_image.IMG_LoadTexture(_render, path);
            return texture;
        }

        public void Clear() => SDL.SDL_RenderClear(_render);

        public void Display() => SDL.SDL_RenderPresent(_render);

        public void DrawObject(GameObject gameObject, SDL.SDL_RendererFlip flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE)
        {
            var texture = gameObject.Texture;
            var center = new SDL.SDL_Point();
            center.x = gameObject.Rect.w / 2;
            center.y = gameObject.Rect.h / 2;
            SDL.SDL_RenderCopyEx(_render, texture.Pointer, ref texture.Rect, ref gameObject.Rect, gameObject.Rotation, ref center, flip);
        }

        public void Destroy() => SDL.SDL_DestroyRenderer(_render);
    }
}
