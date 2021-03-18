using KernelErr0rTheGame.Structures;

namespace KernelErr0rTheGame
{
    public static class SceneManager
    {
        private static Scene _currentScene;
        public static Scene Scene => _currentScene;

        public static void LoadNewScene(Scene newScene)
        {
            if (_currentScene != null)
                foreach (var gameObject in _currentScene.SceneObjects)
                    gameObject.Destroy();

            _currentScene = newScene;
            _currentScene.InitalizeGameObjects();
        }

        public static void DestroyScene()
        {
            if (_currentScene != null)
            {
                foreach (var gameObject in _currentScene.SceneObjects)
                    gameObject.Destroy();

                foreach (var gameObject in _currentScene.StaticSceneObjects)
                    gameObject.Destroy();
            }

            _currentScene = null;
        }
    }
}
