using KernelErr0rTheGame.Core;
using KernelErr0rTheGame.Enums;
using KernelErr0rTheGame.Structures;

namespace KernelErr0rTheGame.GameEnviroment
{
    public class Game : Scene
    {
        protected override void CreateGameObjects()
        {
            AddGameObject(new Player(Vector2.Zero, 0, 0.1f, ObjectTag.Player));
        }
    }
}
