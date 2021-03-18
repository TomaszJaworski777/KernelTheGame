using KernelErr0rTheGame.Core;
using System;
using System.Collections.Generic;

namespace KernelErr0rTheGame.Structures
{
    public abstract class Scene
    {
        public List<GameObject> SceneObjects = new List<GameObject>();
        public List<GameObject> StaticSceneObjects = new List<GameObject>();

        public Scene()
        {
            CreateGameObjects();
        }

        protected abstract void CreateGameObjects();

        public void AddGameObject(GameObject gameObject)
        {
            if(!SceneObjects.Contains(gameObject))
                SceneObjects.Add(gameObject);
        }
        public void AddStaticGameObject(GameObject gameObject)
        {
            if (!StaticSceneObjects.Contains(gameObject))
                StaticSceneObjects.Add(gameObject);
        }

        public void InitalizeGameObjects()
        {
            foreach (var gameObject in SceneObjects)
            {
                gameObject.Start();
            }
        }

        public void UpdateGameObjects(float frameTime)
        {
            foreach (var gameObject in SceneObjects)
            {
                gameObject.Update(frameTime);
            }

            foreach (var gameObject in SceneObjects)
            {
                gameObject.LateUpdate(frameTime);
            }
        }

        public void DrawGameObjects(Render _render)
        {
            foreach (var gameObject in SceneObjects)
            {
                _render.DrawObject(gameObject, gameObject.FlipMode);
            }

            foreach (var gameObject in StaticSceneObjects)
            {
                _render.DrawObject(gameObject, gameObject.FlipMode);
            }
        }
    }
}
