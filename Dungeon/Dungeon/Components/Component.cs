using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dungeon.Components
{
    public abstract class Component
    {
        public GameObject GameObject { get; private set; }

        /// <summary>
        /// Called by the GameObject for Component-specific setup
        /// </summary>
        public void Init(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        /// <summary>
        /// Called on creation of the GameObject.
        /// </summary>
        public virtual void Start()
        {
        }

        /// <summary>
        /// Called once every update tick
        /// </summary>
        /// <param name="gameTime">GameTime object for ticks</param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Called once every draw tick. Use it for rendering.
        /// </summary>
        /// <param name="gameTime">GameTime object for ticks</param>
        /// <param name="spriteBatch">The SpriteBatch to render from</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public override string ToString()
        {
            return $"Component {GetType()}";
        }
    }
}