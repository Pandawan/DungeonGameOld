using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Dungeon.Components;

namespace Dungeon
{
    public class GameObject
    {
        public string Name { get; set; }
        public Vector2 Position { get; set; }

        private List<Component> Components { get; set; }

        public GameObject(string name, Vector2 position)
        {
            Name = name;
            Position = position;
            Components = new List<Component>();

            // Initialize GameObject and its components if it already had some
            Init();
        }

        public GameObject(string name, Vector2 position, List<Component> components)
        {
            Name = name;
            Position = position;
            Components = components;

            // Initialize GameObject and its components if it already had some
            Init();
        }

        /// <summary>
        /// Initialize the GameObject and its Components
        /// </summary>
        private void Init()
        {
            // Initialize every Component
            foreach (Component component in Components)
            {
                component.Init(this);
                component.Start();
            }
        }

        /// <summary>
        /// Call the GameObject's Components' Update methods
        /// </summary>
        public void Update(GameTime gameTime)
        {
            // Call every Component's Update
            foreach (Component component in Components)
            {
                component.Update(gameTime);
            }
        }


        /// <summary>
        /// Call the GameObject's Components' Draw methods
        /// </summary>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Call every Component's Draw
            foreach (Component component in Components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        /// <summary>
        /// Add a Component to this GameObject and initialize it
        /// </summary>
        /// <param name="component"></param>
        public void AddComponent(Component component)
        {
            Components.Add(component);
            component.Init(this);
            component.Start();
        }

        /// <summary>
        /// Get a Component of the given type on this GameObject
        /// </summary>
        /// <typeparam name="T">The type to search for</typeparam>
        /// <returns>Returns the component of the type or null</returns>
        public T GetComponent<T>() where T : Component
        {
            return (T) Components.Find((component) => component is T);
        }

        public override string ToString()
        {
            return $"GameObject {Name}";
        }
    }
}