using KernelErr0rTheGame.Enums;
using KernelErr0rTheGame.InputSystem;
using KernelErr0rTheGame.Structures;

namespace KernelErr0rTheGame.GameEnviroment
{
    public class Player : GameObject
    {
        public Player(Vector2 position = new Vector2(), float rotation = 0, float scale = 1, ObjectTag tag = ObjectTag.None) 
            : base(position, rotation, scale, tag) { }

        public override void Start()
        {
            LoadTexture("main_character.png", 464, 1309, 464, 1309);
        }

        public override void Update(float frameTime)
        {
            var movementDirection = Input.GetMovementDirection();
            Translate(movementDirection * 450 * frameTime);

            if (movementDirection.X > 0) FlipMode = SDL2.SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;
            else if(movementDirection.X < 0) FlipMode = SDL2.SDL.SDL_RendererFlip.SDL_FLIP_NONE;
        }

        public override void LateUpdate(float frameTime)
        {
            
        }
    }
}
