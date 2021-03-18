using System;
using KernelErr0rTheGame.Core;
using KernelErr0rTheGame.Enums;
using SDL2;

namespace KernelErr0rTheGame.Structures
{
    public abstract class GameObject
    {
        public Vector2 Position;
        public float Rotation;
        public float Scale;
        public Texture Texture;
        public SDL.SDL_Rect Rect;
        public ObjectTag Tag = ObjectTag.None;
        public SDL.SDL_RendererFlip FlipMode = SDL.SDL_RendererFlip.SDL_FLIP_NONE;

        protected Render render;

        protected GameObject(Vector2 position = new Vector2(), float rotation = 0, float scale = 1, ObjectTag tag = ObjectTag.None)
        {
            render = Render.reference;

            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        protected void LoadTexture(string path, int width, int height, int gameWidth, int gameHeight)
        {
            Texture = render.CreateTextureFromFile(path, width, height);
            UpdatePosition();
            UpdateScale(gameWidth, gameHeight);
        }

        protected void LoadFlatColor(byte r, byte g, byte b, byte a)
        {
/*            Texture.Pointer = SDL_CreateTexture(renderer, SDL_PIXELFORMAT_RGBA8888, SDL_TEXTUREACCESS_TARGET, 1024, 768);
            SDL.SDL_SetRenderTarget(renderer, texture);
            SDL.SDL_RenderClear(renderer);
            SDL.SDL_RenderDrawRect(renderer, Rect);
            SDL.SDL_SetRenderDrawColor(renderer, r, g, b, a);
            SDL.SDL_RenderFillRect(renderer, Rect);
            SDL.SDL_SetRenderTarget(renderer, IntPtr.Zero);*/
        }
        
        public void Translate(Vector2 translation)
        {
            Position += translation;
            UpdatePosition();
        }
        public void Translate(float x, float y)
        {
            Position += new Vector2(x,y);
            UpdatePosition();
        }
        public void SetPosition(Vector2 position)
        {
            Position = position;
            UpdatePosition();
        }
        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
            UpdatePosition();
        }

        public void Rotate(float x) => Rotation += x;
        public void SetRotation(float x) => Rotation = x;

        private void UpdatePosition()
        {
            Rect.x = (int)Position.X;
            Rect.y = (int)Position.Y;
        }

        private void UpdateScale(int width, int height)
        {
            Rect.w = (int)(width * Scale);
            Rect.h = (int)(height * Scale);
        }

        public virtual void Start() { }
        public virtual void Update(float frameTime) { }
        public virtual void LateUpdate(float frameTime) { }

        public void Destroy()
        {
            SDL.SDL_DestroyTexture(Texture.Pointer);
            render = null;
        }
    }
}
