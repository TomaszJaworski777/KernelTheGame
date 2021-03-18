using System;
using SDL2;

namespace KernelErr0rTheGame.Structures
{
    public class Texture
    {
        public SDL.SDL_Rect Rect;
        public string ImagePath;
        public IntPtr Pointer;

        public Texture(string path, int width, int height)
        {
            Rect = new SDL.SDL_Rect();
            Rect.w = width;
            Rect.h = height;
            ImagePath = path;
            Pointer = IntPtr.Zero;
        }
    }
}
