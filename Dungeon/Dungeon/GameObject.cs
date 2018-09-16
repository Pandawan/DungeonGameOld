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

        private List<Component> Components { get; set; }

        // Keep a reference of the Transform component because it is used so often
        private Transform transform;
        public Transform Transform
        {
            get
            {
                // Get the transform, if it's null find it in Components List, then return
                return transform ?? (transform = (Transform) Components.Find((component) => component is Transform));
            }
            set => transform = value;
        }

        public GameObject(string name)
        {
            Name = name;
            Components = new List<Component>();
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

        #region Component Management

        /// <summary>
        /// Add a Component to this GameObject and initialize it
        /// </summary>
        /// <param name="component">The Component to add</param>
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

        #endregion

        public override string ToString()
        {
            return $"GameObject {Name}";
        }
    }
}