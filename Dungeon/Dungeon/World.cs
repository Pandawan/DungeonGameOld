using System;
using System.Collections.Generic;
using Dungeon.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    public class World
    {
        public List<GameObject> GameObjects { get; private set; }
        public ContentManager Content { get; set; }

        public World()
        {
            GameObjects = new List<GameObject>();
        }

        #region Getters/Setters

        /// <summary>
        /// Set the Content to pass to Renderers
        /// </summary>
        /// <param name="content"></param>
        public void SetContent(ContentManager content)
        {
            Content = content;
        }

        #endregion
        
        #region Lifecycle

        /// <summary>
        /// Called once the World is ready
        /// </summary>
        public void Init()
        {
            GameObject testObject = new GameObject("Test", Vector2.Zero);
            testObject.AddComponent(new SpriteRenderer(Content, "panda"));
            GameObjects.Add(testObject);
        }

        /// <summary>
        /// Update every GameObject in the world
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            // Call every GameObject's Update
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.Update(gameTime);
            }
        }

        /// <summary>
        /// Draw every GameObject in the world
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Call every GameObject's Draw
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.Draw(gameTime, spriteBatch);
            }
        }

        #endregion

        #region GameObject Management
        
        /// <summary>
        /// Destroy a GameObject and remove from the world
        /// </summary>
        /// <param name="gameObject">The GameObject to remove</param>
        public void DestroyGameObject(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        /// <summary>
        /// Find a GameObject with the given name
        /// </summary>
        /// <param name="name">The name to search for</param>
        /// <returns></returns>
        public GameObject FindGameObject(string name)
        {
            return GameObjects.Find((gameObject) => gameObject.Name == name);
        }

        #endregion


        public override string ToString()
        {
            return $"World";
        }
    }
}