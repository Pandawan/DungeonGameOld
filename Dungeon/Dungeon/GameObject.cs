using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon
{
    /// <summary>
    /// An object in the world.
    /// Can hold Components for behavior/logic.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// This GameObject's name
        /// </summary>
        public string Name { get; set; }
        
        // Keep a reference of the Transform component because it is used so often
        private Transform transform;

        /// <summary>
        /// Reference to the Transform Component on this GameObject
        /// </summary>
        public Transform Transform
        {
            get
            {
                // Get the transform, if it's null find it in Components List, then return
                return transform ?? (transform = (Transform) Components.Find((component) => component is Transform));
            }
            set => transform = value;
        }

        // List of all components
        private List<Component> Components { get; set; }

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