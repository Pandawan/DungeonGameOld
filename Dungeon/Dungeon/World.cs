using System;
using System.Collections.Generic;
using Dungeon.Player;
using Dungeon.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    /// <summary>
    /// Manages all the GameObjects in the Scene
    /// </summary>
    public class World
    {
        /// <summary>
        /// List of all GameObjects in the world
        /// </summary>
        public List<GameObject> GameObjects { get; private set; }

        public World()
        {
            GameObjects = new List<GameObject>();
        }

        #region Lifecycle

        /// <summary>
        /// Called once the World is ready
        /// </summary>
        public void Init()
        {
            // TODO: Move this to another class?
            // Create the player
            GameObject player = CreateGameObject("Player", Vector2.Zero);
            player.AddComponent(new SpriteRenderer("panda"));
            player.GetComponent<SpriteRenderer>().SortingLayer = SortingLayer.Player;
            player.Transform.Move(player.Transform.GetRelativeCenter());
            player.AddComponent(new PlayerController(5f));

            // Create a tile
            GameObject tile = CreateGameObject("Tile", Vector2.Zero);
            tile.AddComponent(new SpriteRenderer("blank", Color.ForestGreen));
            tile.GetComponent<SpriteRenderer>().SortingLayer = SortingLayer.World;
            tile.Transform.Scale = new Vector2(100, 10);
            tile.Transform.Move(tile.Transform.GetRelativeCenter());
            tile.Transform.Move(new Vector2(100, 250));
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
        /// <param name="spriteBatch">The spriteBatch object to draw to</param>
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

        public GameObject CreateGameObject(string name, Vector2 position)
        {
            // Create a GameObject
            GameObject gameObject = new GameObject(name);
            // Add a basic Transform
            gameObject.AddComponent(new Transform(position));
            // Add it to the list of GameObjects
            GameObjects.Add(gameObject);
            // Return it for use
            return gameObject;
        }

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